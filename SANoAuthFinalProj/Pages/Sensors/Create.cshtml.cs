using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SANoAuthFinalProj.Models;

namespace SANoAuthFinalProj.Pages.Sensors
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
        public Sensor Sensor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sensor.Add(Sensor);

            // added commands to unlock/lock permissions to set ID params
            //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Sensor ON");
            await _context.SaveChangesAsync();
            //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Sensor OFF");

            return RedirectToPage("./Index");
        }
    }
}