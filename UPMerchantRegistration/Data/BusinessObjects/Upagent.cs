using System;
using System.Collections.Generic;

namespace UPMerchantRegistration
{
    public partial class Upagent
    {
        public Upagent()
        {
            Businessproprietors = new HashSet<Businessproprietors>();
        }

        public int Id { get; set; }
        public string Phonenumber { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Personalemail { get; set; }
        public string Homeaddress { get; set; }
        public int? Stateid { get; set; }
        public int? Lgaid { get; set; }
        public string Gender { get; set; }
        public string Officeaddress { get; set; }
        public int? Officestateid { get; set; }
        public int? Officelgaid { get; set; }
        public int? Desstateid { get; set; }
        public int? Deslgaid { get; set; }
        public string Businessname { get; set; }
        public string Rcnumber { get; set; }
        public string Natureofbusiness { get; set; }
        public string Turnover { get; set; }
        public string Profitbeforetax { get; set; }
        public string Businessemail { get; set; }
        public string Businessphone { get; set; }
        public string Noofbusinessyears { get; set; }
        public string Noofproprietors { get; set; }
        public string Noofshareholders { get; set; }
        public string Selectedlgas { get; set; }
        public string Selectedshareholders { get; set; }
        public string Selectedproprietors { get; set; }
        public string Trandate { get; set; }
        public string PaymentStatus { get; set; }
        public int? Acctypeid { get; set; }
        public string invoiceNumber { get; set; }
        public string PATransactionid { get; set; }
        public virtual Acctype Acctype { get; set; }
        public virtual Lga Lga { get; set; }
        public virtual Lga Officelga { get; set; }
        public virtual State Officestate { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Businessproprietors> Businessproprietors { get; set; }
    }
}
