using System;
using System.Collections.Generic;

#nullable disable

namespace WebMuNG
{
    public partial class MembCredit
    {
        public string MembId { get; set; }
        public int Credits { get; set; }
        public int? Used { get; set; }
    }
}
