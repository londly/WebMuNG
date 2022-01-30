using System;
using System.Collections.Generic;

#nullable disable

namespace WebMuNG
{
    public partial class MasterSkillTree
    {
        public string Name { get; set; }
        public int? MasterLevel { get; set; }
        public int? MasterPoint { get; set; }
        public long? MasterExperience { get; set; }
        public byte[] MasterSkill { get; set; }
    }
}
