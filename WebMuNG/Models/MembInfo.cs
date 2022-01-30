using System;
using System.Collections.Generic;

#nullable disable

namespace WebMuNG
{
    public partial class MembInfo
    {
        public int MembGuid { get; set; }
        public string MembId { get; set; }
        public string MembPwd { get; set; }
        public string MembName { get; set; }
        public string SnoNumb { get; set; }
        public string PostCode { get; set; }
        public string AddrInfo { get; set; }
        public string AddrDeta { get; set; }
        public string TelNumb { get; set; }
        public string PhonNumb { get; set; }
        public string MailAddr { get; set; }
        public string FpasQues { get; set; }
        public string FpasAnsw { get; set; }
        public string JobCode { get; set; }
        public DateTime? ApplDays { get; set; }
        public DateTime? ModiDays { get; set; }
        public DateTime? OutDays { get; set; }
        public DateTime? TrueDays { get; set; }
        public string MailChek { get; set; }
        public string BlocCode { get; set; }
        public string Ctl1Code { get; set; }
        public int AccountLevel { get; set; }
        public DateTime AccountExpireDate { get; set; }
        public int Admin { get; set; }
        public DateTime? LastLogin { get; set; }
        public int Activated { get; set; }
        public string ActivationId { get; set; }
        public string LastLoginIp { get; set; }
        public string Country { get; set; }
        public string DmnCountry { get; set; }
        public string Discord { get; set; }
        public string DiscordName { get; set; }
        public string Hwid { get; set; }
        public bool Auth2fa { get; set; }
    }
}
