using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SANoAuthFinalProj.Models;

namespace SANoAuthFinalProj.Pages.DataPoints
{
    public class CreateModel : PageModel
    {
        private readonly SANoAuthFinalProj.Models.SAAppContext _context;

        public CreateModel(SANoAuthFinalProj.Models.SAAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DataPoint DataPoint { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DataPoint.Add(DataPoint);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}