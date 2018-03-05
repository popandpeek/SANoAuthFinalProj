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
    public class DetailsModel : PageModel
    {
        private readonly SANoAuthFinalProj.Models.SAAppContext _context;

        public DetailsModel(SANoAuthFinalProj.Models.SAAppContext context)
        {
            _context = context;
        }

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
    }
}
