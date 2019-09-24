using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EnquiryResponse;
using UPMerchantRegistration.Data.BusinessObjects;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace UPMerchantRegistration.Areas.Identity.Pages.Account
{
    public class jsonLGS
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

    }
    public class RegisterModel : PageModel
    {
        private readonly UPAGENTMANAGERContext _context;

        public RegisterModel(UPAGENTMANAGERContext context)
        {
            _context = context;
        }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public string JSONLGAs { get; set; }

        public string Gender { get; set; }

        [BindProperty]
        public string desJSON { get; set; }

        [BindProperty]
        public string totalamount { get; set; }

        [BindProperty]
        public string Transactionid { get; set; }

        public string invoiceNumber { get; set; }

        public string PATransactionid { get; set; }

        [BindProperty]
        [Display(Name = "Phone Number (Must be registered with PayAttitude")]
        [Required(ErrorMessage = "A phone number is required")]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string noofselectedlgas { get; set; }

        [BindProperty]
        public string PaymentRef { get; set; }

        [BindProperty]
        public string successstatus { get; set; }

        [BindProperty]
        public string MutantStatus { get; set; }

        [BindProperty]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Required field")]
        public string FirstName { get; set; }

        [BindProperty]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [BindProperty]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Required field")]
        public string LastName { get; set; }

        [BindProperty]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }

        [BindProperty]
        public List<SelectListItem> GenderList { get; set; }

        [BindProperty]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Required field")]
        public string Address { get; set; }


        [BindProperty]
        [Display(Name = "State")]
        [Required(ErrorMessage = "Required field")]
        public int Stateid { get; set; }

        [BindProperty]
        [Display(Name = "LGA")]
        [Required(ErrorMessage = "Required field")]
        public int Lgaid { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Required field")]
        public List<SelectListItem> StateList { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Required field")]
        public List<SelectListItem> LGAList { get; set; }

        //office address || COLUMN 2
        [BindProperty]
        [Display(Name = "Office Address")]
        [Required(ErrorMessage = "Required field")]
        public string OfficeAddress { get; set; }

        [BindProperty]
        [Display(Name = "State")]
        [Required(ErrorMessage = "Required field")]
        public int Officestateid { get; set; }

        [BindProperty]
        [Display(Name = "LGA")]
        [Required(ErrorMessage = "Required field")]
        public int Officelgaid { get; set; }

        //[BindProperty]
        //[Required(ErrorMessage = "Required field")]
        //public List<SelectListItem> OfficeStateList { get; set; }

        //[BindProperty]
        //[Required(ErrorMessage = "Required field")]
        //public List<SelectListItem> OfficeLGAList { get; set; }

        // Desired address 

        [BindProperty]
        [Display(Name = "State")]
        [Required(ErrorMessage = "Required field")]
        public int Desstateid { get; set; }


        [BindProperty]
        public bool LGAList2 { get; set; }

        [BindProperty]
        [Display(Name = "LGA")]
        [Required(ErrorMessage = "Required field")]
        public int Deslgaid { get; set; }

        //[BindProperty]
        //[Required(ErrorMessage = "Required field")]
        //public List<SelectListItem> DesOfficeStateList { get; set; }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public class StateResult
        {
            public string StateName { get; set; }
            public int StateId { get; set; }
        }

        public class LGAResult
        {
            public int id { get; set; }
            public string lganame { get; set; }
        }


        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            GenderList = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Male", Value="M"},
                new SelectListItem{ Text="Female", Value="F"},
            };

            StateList = _context.State.Select(a =>
                                      new SelectListItem
                                      {
                                          Value = a.Id.ToString(),
                                          Text = a.Statename
                                      }).ToList();

            //LGAList = _context.Lga.Select(a =>
            //                          new SelectListItem
            //                          {
            //                              Value = a.Id.ToString(),
            //                              Text = a.Lganame
            //                          }).ToList();
            //get my locations
        }

        public IActionResult OnGetFetchLGAs(int id)
        {
            var lgalist = _context.Lga.Where(t => t.Stateid == id).OrderBy(x=> x.Lganame).ToList();
            if (lgalist.Count > 0)
            {
                var data = new List<LGAResult>();
                if (lgalist.Count > 1)
                {

                    foreach (var i in lgalist)
                    {
                        data.Add(new LGAResult
                        {
                            lganame = i.Lganame,
                            id = i.Id
                        });
                        //data.StateName = i.StateName;
                        //data.StateId = i.Id;
                    }
                }
                else
                {
                    data.Add(new LGAResult
                    {
                        lganame = lgalist.FirstOrDefault()?.Lganame,
                        id = lgalist.FirstOrDefault().Id
                    });
                    //data.StateName = stateList.FirstOrDefault()?.StateName;
                    //data.StateId = stateList.FirstOrDefault().Id;
                }
                return new JsonResult(data);

            }
            else
            {
                var data = new
                {
                    lganame = "",
                    id = ""
                };
                return new JsonResult(data);
            }

        }

        //public ActionResult Details(int Id)
        //{
        //    FriendsInfo frnds = new FriendsInfo();
        //    frnds = db.FriendsInfo.Find(Id);
        //    return PartialViewResult("_Details", frnds);
        //}

        public ActionResult PartialViewResult(string v, RegisterModel model)
        {
            return PartialViewResult("_Summary", model);
        }

        public IActionResult OnPost(string returnUrl = null)
        {



            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {

                //tid 
                var random = new Random();
                //var date = new DateTime();
                //var tid = PhoneNumber.Substring(7, 4) + FirstName.Substring(0, 3).ToUpper() + random.Next(1000, 1000000);
                var tid = PhoneNumber.Substring(3, 8) + FirstName.Substring(0, 3).ToUpper() + DateTime.Now.ToString("ddMMyyHHmmss");
                //var normed = Regex.Replace(tid, @"\s+", "");
                var normed = tid.Replace(" ", String.Empty);
                Transactionid = normed;
                //end tid
                //var propjlgas = JSONLGAs.Replace(@"\\", "");
                ////get no of lgas
                ////var result = (jsonLGS)JsonConvert.DeserializeObject(JSONLGAs, typeof(jsonLGS));
                //int lgacount = JSONLGAs.Count(f => f == ',');
                //lgacount += 1;
                //noofselectedlgas = lgacount.ToString();
                //end get no of lgas

                //deseriliaze entire model
                var nos = JsonConvert.SerializeObject(ModelState.Values);
                //
                desJSON = nos;

                //get total
                double total = 5000.00 * Double.Parse(noofselectedlgas);
                var amt = total.ToString("0.00");
                var final = amt + " NGN";
                totalamount = amt;
                ViewData["totalamount"] = final;
                //
                string selectedgender = Request.Form["sex"].ToString();
                Gender = selectedgender;

                //var agent = new Upagent { Phonenumber = PhoneNumber, Firstname = FirstName, Middlename = MiddleName, Lastname = LastName,
                //    Gender = selectedgender, Homeaddress = Address, Stateid = Stateid, Lgaid = Lgaid, Personalemail = Email, Officeaddress = OfficeAddress,
                //    Officestateid = Officestateid, Officelgaid = Officelgaid, Desstateid = Desstateid, Deslgaid = Deslgaid, Selectedlgas = JSONLGAs
                //};
            }

            StateList = _context.State.Select(a =>
                                      new SelectListItem
                                      {
                                          Value = a.Id.ToString(),
                                          Text = a.Statename
                                      }).ToList();

            LGAList = _context.Lga.Select(a =>
                                      new SelectListItem
                                      {
                                          Value = a.Id.ToString(),
                                          Text = a.Lganame
                                      }).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostSaveAgentAsync()
        {
            string merchantid = "";
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            string paendpoint = configuration["payattititudeendpoint"];
            //
            var random = new Random();
            var tid = PhoneNumber.Substring(3, 8) + FirstName.Substring(0, 3).ToUpper() + DateTime.Now.ToString("ddMMyyHHmmss");
            //var normed = Regex.Replace(tid, @"\s+", "");
            var normed = tid.Replace(" ", String.Empty);
            Transactionid = normed;
            double totalamt = 5000.00 * Double.Parse(noofselectedlgas);
            var am = totalamt.ToString("0.00");
            //
            Pwpresponse response = new Pwpresponse();
            Pwprequest payload = new Pwprequest()
            {
                Description = "UP AGENT REGISTRATION FEE",
                TrxId = normed,
                Amount = am,
                Phone = PhoneNumber
            };
            var despayload = JsonConvert.SerializeObject(payload);

            //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => {
            //    return true;
            //};
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClient client = CreateWebRequest();

            var resp = await client.PostAsJsonAsync(paendpoint, payload);

            if (!resp.IsSuccessStatusCode)
            {
                //SuccessResponse response = new SuccessResponse {
                response.status = null;
                response.amount = null;
                response.approvalCode = null;
                response.date = DateTime.Now.ToString();
                response.holder = null;
                response.id = null;
                response.paymentRef = null;
                response.requestId = null;
                response.existing = null;
                response.phone = null;
                response.success = null;
                response.uan = null;
                MutantStatus = "A network error occured, Please try again";
                return Page();
            }
            else
            {
                var readResult = await resp.Content.ReadAsStringAsync();
                var dresult = (Pwpresponse)JsonConvert.DeserializeObject(readResult, typeof(Pwpresponse));

                response.status = dresult.status;
                response.amount = dresult.amount;
                response.approvalCode = dresult.approvalCode;
                response.date = dresult.date;
                response.holder = dresult.holder;
                response.id = dresult.id;
                response.paymentRef = dresult.paymentRef;
                response.requestId = dresult.requestId;
                response.existing = dresult.existing;
                response.phone = dresult.phone;
                response.success = dresult.success;
                response.uan = dresult.uan;

                if (response.success == "true")
                    try
                    {
                        successstatus = response.success;
                        var agent = new Upagent
                        {
                            Phonenumber = PhoneNumber,
                            Firstname = FirstName,
                            Middlename = MiddleName,
                            Lastname = LastName,
                            Gender = Gender,
                            Homeaddress = Address,
                            Stateid = Stateid,
                            Lgaid = Lgaid,
                            Personalemail = Email,
                            Officeaddress = OfficeAddress,
                            Officestateid = Officestateid,
                            Officelgaid = Officelgaid,
                            Desstateid = Desstateid,
                            Deslgaid = Deslgaid,
                            Selectedlgas = JSONLGAs,
                            invoiceNumber = normed,
                            PATransactionid = dresult.paymentRef,
                            Acctypeid = 1,
                            PaymentStatus = "1",
                            Trandate = DateTime.Now.ToString()
                        };
                        _context.Add(agent);
                        await _context.SaveChangesAsync();
                        return RedirectToPage("./Success");                       
                    }
                    catch (Exception e) { }
                else
                {
                    var agent = new Upagent
                    {
                        Phonenumber = PhoneNumber,
                        Firstname = FirstName,
                        Middlename = MiddleName,
                        Lastname = LastName,
                        Gender = Gender,
                        Homeaddress = Address,
                        Stateid = Stateid,
                        Lgaid = Lgaid,
                        Personalemail = Email,
                        Officeaddress = OfficeAddress,
                        Officestateid = Officestateid,
                        Officelgaid = Officelgaid,
                        Desstateid = Desstateid,
                        Deslgaid = Deslgaid,
                        Selectedlgas = JSONLGAs,
                        invoiceNumber = normed,
                        PATransactionid = dresult.paymentRef,
                        Acctypeid = 1,
                        PaymentStatus = "0",
                        Trandate = DateTime.Now.ToString()

                    };
                    _context.Add(agent);
                    await _context.SaveChangesAsync();

                    StateList = _context.State.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.Id.ToString(),
                                              Text = a.Statename
                                          }).ToList();

                    LGAList = _context.Lga.Select(a =>
                                              new SelectListItem
                                              {
                                                  Value = a.Id.ToString(),
                                                  Text = a.Lganame
                                              }).ToList();
                    Transactionid = null;
                    MutantStatus = dresult.status;
                    return Page();
                }

                StateList = _context.State.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.Id.ToString(),
                                              Text = a.Statename
                                          }).ToList();

                LGAList = _context.Lga.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.Id.ToString(),
                                              Text = a.Lganame
                                          }).ToList();
                return Page();    
            }
        }
            public IActionResult OnGetFetchpay(string json)
            {


                var result = (Welcome)JsonConvert.DeserializeObject(json, typeof(Welcome));

                if (json != null)
                {
                    var data = new
                    {
                        Pitch = "Hey",
                        Good = "Yes",
                    };
                    return new JsonResult(data);
                    //return new JsonResult (new { Status = true });

                }
                else
                {
                    var data = new
                    {
                        Pitch = "put something",
                        Good = "put something",
                    };
                    return new JsonResult(data);
                }

            }

            public void OnPostSave([FromBody]Upagent person)
            {
                //do something with the person class
            }

            public static HttpClient CreateWebRequest()
            {
                //var url = "http://test.payattitude.com/proc/api/transaction/makepayment/";

                var builder = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json");
                var configuration = builder.Build();
                string paendpoint = configuration["payattititudeendpoint"];

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(paendpoint);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            }
    }
}
