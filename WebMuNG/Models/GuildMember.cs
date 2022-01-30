using System;
using System.Collections.Generic;

#nullable disable

namespace WebMuNG
{
    public partial class GuildMember
    {
        public string Name { get; set; }
        public string GName { get; set; }
        public byte? GLevel { get; set; }
        public byte GStatus { get; set; }

        public virtual Guild GNameNavigation { get; set; }
    }
}
