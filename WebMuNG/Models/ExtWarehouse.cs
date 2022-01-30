using System;
using System.Collections.Generic;

#nullable disable

namespace WebMuNG
{
    public partial class ExtWarehouse
    {
        public string AccountId { get; set; }
        public byte[] Items { get; set; }
        public int? Money { get; set; }
        public int Number { get; set; }
    }
}
