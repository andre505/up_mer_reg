using System;
using System.Collections.Generic;

namespace UPMerchantRegistration
{
    public partial class Acctype
    {
        public Acctype()
        {
            Upagent = new HashSet<Upagent>();
        }

        public int Id { get; set; }
        public string Accounttype { get; set; }

        public virtual ICollection<Upagent> Upagent { get; set; }
    }
}
