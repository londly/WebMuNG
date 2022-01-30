using System;
using System.Collections.Generic;

namespace WebMuNG.Models
{
    public class MyAccount
    {
        public string username { get; set; }
        public byte connected { get; set; }
        public string UserMail { get; set; }
        public string CharName { get; set; }
        public int CharLevel { get; set; }
        public int CharResests { get; set; }
        public byte CharClass { get; set; }
        public int CharSTR { get; set; }
        public int CharAGI { get; set; }
        public int CharVIT { get; set; }
        public int CharENE { get; set; }
        public int CharCMD { get; set; }
        public Int16 CharMap { get; set; }
        public Int16 CharMapPosX { get; set; }
        public Int16 CharMapPosY { get; set; }
        public string CharGuildName { get; set; }
        public string Password { get; set; }
        public byte[] CharInventory { get; set; }

        public class CharacterMapping
        {
            public int CharClassID { get; set; }
            public string CharClassName { get; set; }
            public string CharClassImage { get; set; }
            public string CharInventoryImage { get; set; }
        }

        public class MapMapping
        {
            public int MapID { get; set; }
            public string MapName { get; set; }
        }


    }
}
