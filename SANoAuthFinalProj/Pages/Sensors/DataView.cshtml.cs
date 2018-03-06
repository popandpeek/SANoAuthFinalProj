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
    public class DataViewModel : PageModel
    {
        private readonly SANoAuthFinalProj.Models.SAAppContext _context;

        public DataViewModel(SANoAuthFinalProj.Models.SAAppContext context)
        {
            _context = context;
        }

        public IList<DataPoint> DPList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // TO DO: 
            // Get a list of DataPoint items frm the DB

            //_context.Sensor.Add(Sensor);

            // NEED:
            // Make this create a list, I think, or do we add post parameter for ID like ./DataView{1} ?
            // and have this work in the view to grab the associated DataPoints from the DB? 

            if (id == null)
            {
                return NotFound();
            }

            string query = "SELECT * FROM DataPoint WHERE ID = {0}";
            DPList = await _context.DataPoint
                .FromSql(query, id)
                .Include(d => d.ID)
                .AsNoTracking()
                .ToListAsync();

            if (DPList == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
