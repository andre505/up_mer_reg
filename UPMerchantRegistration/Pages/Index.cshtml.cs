using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UPMerchantRegistration.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
        public List<SelectListItem> Countries { get; set; }
         = new List<SelectListItem>
        {
        new SelectListItem("Individual", "ind"),
        new SelectListItem("Registered Business Name", "regbizname"),
        new SelectListItem("Registered Company", "regcomp")
        }; // used to populate the list of options

        public string Country { get; set; }
    }
}
