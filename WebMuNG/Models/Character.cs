using System;
using System.Collections.Generic;

#nullable disable

namespace WebMuNG
{
    public partial class Character
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public int? CLevel { get; set; }
        public int? LevelUpPoint { get; set; }
        public byte? Class { get; set; }
        public int? Experience { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Vitality { get; set; }
        public int? Energy { get; set; }
        public int? Leadership { get; set; }
        public byte[] Inventory { get; set; }
        public byte[] MagicList { get; set; }
        public int? Money { get; set; }
        public float? Life { get; set; }
        public float? MaxLife { get; set; }
        public float? Mana { get; set; }
        public float? MaxMana { get; set; }
        public float? Bp { get; set; }
        public float? MaxBp { get; set; }
        public float? Shield { get; set; }
        public float? MaxShield { get; set; }
        public short? MapNumber { get; set; }
        public short? MapPosX { get; set; }
        public short? MapPosY { get; set; }
        public byte? MapDir { get; set; }
        public int? PkCount { get; set; }
        public int? PkLevel { get; set; }
        public int? PkTime { get; set; }
        public DateTime? Mdate { get; set; }
        public DateTime? Ldate { get; set; }
        public byte? CtlCode { get; set; }
        public byte? DbVersion { get; set; }
        public byte[] Quest { get; set; }
        public short? ChatLimitTime { get; set; }
        public int? FruitPoint { get; set; }
        public byte[] EffectList { get; set; }
        public int FruitAddPoint { get; set; }
        public int FruitSubPoint { get; set; }
        public int ExtInventory { get; set; }
        public int ResetCount { get; set; }
        public int ResetDay { get; set; }
        public int ResetWek { get; set; }
        public int ResetMon { get; set; }
        public int MasterResetCount { get; set; }
        public int MasterResetDay { get; set; }
        public int MasterResetWek { get; set; }
        public int MasterResetMon { get; set; }
        public int? LastResetTime { get; set; }
        public int MuId { get; set; }
        public int? LastGresetTime { get; set; }
        public int Resets { get; set; }
        public int GrandResets { get; set; }
        public int DmnPkCount { get; set; }
        public int DmnLastServerPkCount { get; set; }
    }
}
