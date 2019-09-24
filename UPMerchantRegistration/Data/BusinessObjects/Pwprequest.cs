using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPMerchantRegistration.Data.BusinessObjects
{
    public class Pwprequest
    {
        public string Description { get; set; }
        public string TrxId { get; set; }
        public string Amount { get; set; }
        public string Phone { get; set; }
    }
}
