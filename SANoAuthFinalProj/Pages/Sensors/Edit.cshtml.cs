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
    public class EditModel : PageModel
    {
        private readonly SANoAuthFinalProj.Models.SAAppContext _context;

        public EditModel(SANoAuthFinalProj.Models.SAAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sensor Sensor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sensor = await _context.Sensor.SingleOrDefaultAsync(m => m.ID == id);

            if (Sensor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExists(Sensor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SensorExists(int id)
        {
            return _context.Sensor.Any(e => e.ID == id);
        }
    }
}
