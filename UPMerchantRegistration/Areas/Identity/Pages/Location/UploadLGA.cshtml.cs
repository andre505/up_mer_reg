using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;

namespace UPMerchantRegistration.Areas.Identity.Pages.Location
{
    public class UploadLGAModel : PageModel
    {

        private readonly UPAGENTMANAGERContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public UploadLGAModel(UPAGENTMANAGERContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
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

        public async Task<IActionResult> OnPostAsync(ICollection<IFormFile> files)
        {
            if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
                _hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            //string rootpath = _hostingEnvironment.WebRootPath;
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            foreach (var fil in files)
            {
                if (fil.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, fil.FileName), FileMode.Create))
                    {
                        await fil.CopyToAsync(fileStream);
                    }
                }
            }
            string fileName = "NGALGA.xlsx";
            string newrootFolder = uploads + "/" + fileName;

            FileInfo file = new FileInfo(newrootFolder);

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["LGA"];
                int totalRows = workSheet.Dimension.Rows;

                for (int i = 2; i <= totalRows; i++)
                {
                    var lgalist = new Lga(workSheet.Cells[i, 1].Value.ToString(), int.Parse(workSheet.Cells[i, 2].Value.ToString()));
                    _context.Add(lgalist);
                }
               
                await _context.SaveChangesAsync();
                return RedirectToPage("./Success");
            }
            return null;
        }

    }
}