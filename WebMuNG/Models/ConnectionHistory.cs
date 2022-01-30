using System;
using System.Collections.Generic;

#nullable disable

namespace WebMuNG
{
    public partial class ConnectionHistory
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string ServerName { get; set; }
        public string Ip { get; set; }
        public DateTime? Date { get; set; }
        public string State { get; set; }
        public string Hwid { get; set; }
    }
}
