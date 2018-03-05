using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SANoAuthFinalProj.Models;

namespace SANoAuthFinalProj.Pages.DataPoints
{
    public class EditModel : PageModel
    {
        private readonly SANoAuthFinalProj.Models.SAAppContext _context;

        public EditModel(SANoAuthFinalProj.Models.SAAppContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DataPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataPointExists(DataPoint.TimeStamp))
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

        private bool DataPointExists(DateTime id)
        {
            return _context.DataPoint.Any(e => e.TimeStamp == id);
        }
    }
}
