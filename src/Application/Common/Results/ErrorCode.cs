﻿namespace Crpg.Application.Common.Results;

/// <summary>
/// A machine-readable error code.
/// </summary>
public enum ErrorCode
{
    ApplicationClosed,
    ApplicationNotFound,
    BattleInvalidPhase,
    BattleNotFound,
    BattleTooFar,
    CharacterGenerationRequirement,
    CharacterLevelRequirementNotMet,
    CharacterNotFound,
    CharacterRecentlyCreated,
    CharacteristicDecreased,
    ClanInvitationClosed,
    ClanInvitationNotFound,
    ClanMemberRoleNotMet,
    ClanNameAlreadyUsed,
    ClanNeedLeader,
    ClanNotFound,
    ClanTagAlreadyUsed,
    Conflict,
    FighterNotACommander,
    InternalError,
    InvalidField,
    ItemAlreadyOwned,
    ItemBadSlot,
    ItemDisabled,
    ItemNotBuyable,
    ItemNotFound,
    ItemNotOwned,
    NotEnoughAttributePoints,
    NotEnoughGold,
    NotEnoughHeirloomPoints,
    NotEnoughSkillPoints,
    NotEnoughWeaponProficiencyPoints,
    PartiesNotOnTheSameSide,
    PartyFighter,
    PartyInBattle,
    PartyNotAFighter,
    PartyNotEnoughTroops,
    PartyNotFound,
    PartyNotInASettlement,
    PartyNotInSight,
    PartyNotSettlementOwner,
    SettlementNotFound,
    SettlementTooFar,
    SkillRequirementNotMet,
    UserAlreadyInAClan,
    UserAlreadyInTheClan,
    UserAlreadyRegisteredToStrategus,
    UserItemMaxRankReached,
    UserItemNotFound,
    UserNotAClanMember,
    UserNotFound,
    UserNotInAClan,
    UserRoleNotMet,
}
