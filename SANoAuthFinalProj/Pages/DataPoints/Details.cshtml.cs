using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SANoAuthFinalProj.Models;

namespace SANoAuthFinalProj.Pages.DataPoints
{
    public class DetailsModel : PageModel
    {
        private readonly SANoAuthFinalProj.Models.SAAppContext _context;

        public DetailsModel(SANoAuthFinalProj.Models.SAAppContext context)
        {
            _context = context;
        }

        public DataPoint DataPoint { get; set; }

        public async Task<IActionResult> OnGetAsync(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DataPoint = await _context.DataPoint.SingleOrDefaultAsync(m => m.TimeStamp == id);

            if (DataPoint == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
