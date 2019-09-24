using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UPMerchantRegistration.Areas.Identity.Pages.Location
{
    public class CreateStateModel : PageModel
    {

        private readonly UPAGENTMANAGERContext _context;

        public CreateStateModel(UPAGENTMANAGERContext context)
        {
            _context = context;
        }


        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }

        public class InputModel
        {

            [Display(Name = "State Code")]
            [Required(ErrorMessage = "Required field")]
            public string StateCode { get; set; }

            [Display(Name = "State Name")]
            [Required(ErrorMessage = "Required field")]
            public string StateName { get; set; }
        }
        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var state = new State { Statecode = Input.StateCode, Statename = Input.StateName};
             _context.Add(state);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Success");
        }

    }
}