using System;
using System.Collections.Generic;

#nullable disable

namespace WebMuNG
{
    public partial class CharacterRealTime
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public string IpAddress { get; set; }
        public bool Online { get; set; }
        public string ServerName { get; set; }
        public int Pklevel { get; set; }
        public int Level { get; set; }
        public int MasterLevel { get; set; }
        public int Reset { get; set; }
        public int MasterReset { get; set; }
        public int Life { get; set; }
        public int MaxLife { get; set; }
        public int Shield { get; set; }
        public int MaxShield { get; set; }
        public int Map { get; set; }
        public int MapX { get; set; }
        public int MapY { get; set; }
        public string Party { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Energy { get; set; }
        public int Leadership { get; set; }
        public int Ruud { get; set; }
        public int Money { get; set; }
        public int Death { get; set; }
        public string Killer { get; set; }
        public int DeathMap { get; set; }
        public int DeathMapX { get; set; }
        public int DeathMapY { get; set; }
        public int Attack { get; set; }
        public string Attacker { get; set; }
        public int AttackMap { get; set; }
        public int AttackMapX { get; set; }
        public int AttackMapY { get; set; }
        public int Class { get; set; }
        public int OfflineFlag { get; set; }
        public int AIndex { get; set; }
        public string DiscordEvent { get; set; }
        public int PartyNumber { get; set; }
    }
}
