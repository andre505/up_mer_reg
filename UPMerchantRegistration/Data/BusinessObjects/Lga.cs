using System;
using System.Collections.Generic;

namespace UPMerchantRegistration
{
    public partial class Lga
    {
        public Lga()
        {
            Businessproprietors = new HashSet<Businessproprietors>();
            Companyshareholders = new HashSet<Companyshareholders>();
            UpagentLga = new HashSet<Upagent>();
            UpagentOfficelga = new HashSet<Upagent>();
        }

        public int Id { get; set; }
        public string Lganame { get; set; }
        public int? Stateid { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Businessproprietors> Businessproprietors { get; set; }
        public virtual ICollection<Companyshareholders> Companyshareholders { get; set; }
        public virtual ICollection<Upagent> UpagentLga { get; set; }
        public virtual ICollection<Upagent> UpagentOfficelga { get; set; }

        public Lga(string lganame, int stateid )
        {          
            this.Lganame = lganame;
            this.Stateid = stateid;
        }
    }
}
