using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPMerchantRegistration.Data.BusinessObjects
{
    public class Pwpresponse
    {
        public string success { get; set; }
        public string status { get; set; }
        public string uan { get; set; }
        public string phone { get; set; }
        public string description { get; set; }
        public string holder { get; set; }
        public string requestId { get; set; }
        public string paymentRef { get; set; }
        public string approvalCode { get; set; }
        public string amount { get; set; }
        public string date { get; set; }
        public string existing { get; set; }
        public string id { get; set; }
    }
}
