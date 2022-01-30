using System;
using System.Collections.Generic;

#nullable disable

namespace WebMuNG
{
    public partial class MembStat
    {
        public string MembId { get; set; }
        public byte? ConnectStat { get; set; }
        public string ServerName { get; set; }
        public string Ip { get; set; }
        public DateTime? ConnectTm { get; set; }
        public DateTime? DisConnectTm { get; set; }
    }
}
