using System;
using System.Collections.Generic;

namespace UPMerchantRegistration
{
    public partial class State
    {
        public State()
        {
            Businessproprietors = new HashSet<Businessproprietors>();
            Companyshareholders = new HashSet<Companyshareholders>();
            Lga = new HashSet<Lga>();
            UpagentOfficestate = new HashSet<Upagent>();
            UpagentState = new HashSet<Upagent>();
        }

        public int Id { get; set; }
        public string Statecode { get; set; }
        public string Statename { get; set; }

        public virtual ICollection<Businessproprietors> Businessproprietors { get; set; }
        public virtual ICollection<Companyshareholders> Companyshareholders { get; set; }
        public virtual ICollection<Lga> Lga { get; set; }
        public virtual ICollection<Upagent> UpagentOfficestate { get; set; }
        public virtual ICollection<Upagent> UpagentState { get; set; }
    }
}
