using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SANoAuthFinalProj.Models;

namespace SANoAuthFinalProj.Pages.Sensors
{
    public class DeleteModel : PageModel
    {
        private readonly SANoAuthFinalProj.Models.SAAppContext _context;

        public DeleteModel(SANoAuthFinalProj.Models.SAAppContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sensor = await _context.Sensor.FindAsync(id);

            if (Sensor != null)
            {
                _context.Sensor.Remove(Sensor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
