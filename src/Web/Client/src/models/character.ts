import Item from '@/models/item';

export default class Character {
  public id: number;

  public name: string;

  public experience: number;

  public level: number;

  public headItem: Item;

  public bodyItem: Item;

  public legsItem: Item;

  public glovesItem: Item;

  public weapon1Item: Item;

  public weapon2Item: Item;

  public weapon3Item: Item;

  public weapon4Item: Item;
}
