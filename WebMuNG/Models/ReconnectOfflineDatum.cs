using System;
using System.Collections.Generic;

#nullable disable

namespace WebMuNG
{
    public partial class ReconnectOfflineDatum
    {
        public string Name { get; set; }
        public int ServerCode { get; set; }
        public byte[] Data { get; set; }
        public int Time { get; set; }
    }
}
