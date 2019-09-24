using System;
using System.Collections.Generic;

namespace UPMerchantRegistration
{
    public partial class Businessproprietors
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public int? Stateid { get; set; }
        public int? Lgaid { get; set; }
        public int? Agentid { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }

        public virtual Upagent Agent { get; set; }
        public virtual Lga Lga { get; set; }
        public virtual State State { get; set; }
    }
}
