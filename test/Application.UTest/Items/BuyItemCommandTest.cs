using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Crpg.Application.Common.Exceptions;
using Crpg.Application.Items.Commands;
using Crpg.Domain.Entities;

namespace Crpg.Application.UTest.Items
{
    public class BuyItemCommandTest : TestBase
    {
        [Test]
        public async Task Basic()
        {
            var user = _db.Users.Add(new User { Gold = 100 });
            var item = _db.Items.Add(new Item { Value = 100 });
            await _db.SaveChangesAsync();

            var handler = new BuyItemCommand.Handler(_db, _mapper);
            var boughtItem = await handler.Handle(new BuyItemCommand
            {
                ItemId = item.Entity.Id,
                UserId = user.Entity.Id,
            }, CancellationToken.None);

            var userDb = await _db.Users
                .Include(u => u.UserItems)
                .FirstAsync(u => u.Id == user.Entity.Id);

            Assert.AreEqual(item.Entity.Id, boughtItem.Id);
            Assert.AreEqual(0, userDb.Gold);
            Assert.IsTrue(userDb.UserItems.Any(i => i.ItemId == boughtItem.Id));
        }

        [Test]
        public async Task NotFoundItem()
        {
            var user = _db.Users.Add(new User { Gold = 100 });
            await _db.SaveChangesAsync();

            var handler = new BuyItemCommand.Handler(_db, _mapper);
            Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(new BuyItemCommand
            {
                ItemId = 1,
                UserId = user.Entity.Id,
            }, CancellationToken.None));
        }

        [Test]
        public async Task NotFoundUser()
        {
            var item = _db.Items.Add(new Item { Value = 100 });
            await _db.SaveChangesAsync();

            var handler = new BuyItemCommand.Handler(_db, _mapper);
            Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(new BuyItemCommand
            {
                ItemId = item.Entity.Id,
                UserId = 1,
            }, CancellationToken.None));
        }

        [Test]
        public async Task NotEnoughGold()
        {
            var user = _db.Users.Add(new User { Gold = 100 });
            var item = _db.Items.Add(new Item { Value = 101 });
            await _db.SaveChangesAsync();

            var handler = new BuyItemCommand.Handler(_db, _mapper);
            Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(new BuyItemCommand
            {
                ItemId = item.Entity.Id,
                UserId = user.Entity.Id,
            }, CancellationToken.None));
        }

        [Test]
        public async Task AlreadyOwningItem()
        {
            var item = _db.Items.Add(new Item {Value = 100});
            var user = _db.Users.Add(new User
            {
                Gold = 100,
                UserItems = new List<UserItem> {new UserItem {ItemId = item.Entity.Id}}
            });
            await _db.SaveChangesAsync();

            var handler = new BuyItemCommand.Handler(_db, _mapper);
            Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(new BuyItemCommand
            {
                ItemId = item.Entity.Id,
                UserId = user.Entity.Id,
            }, CancellationToken.None));
        }
    }
}