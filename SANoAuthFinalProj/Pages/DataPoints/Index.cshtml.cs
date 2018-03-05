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
    public class IndexModel : PageModel
    {
        private readonly SANoAuthFinalProj.Models.SAAppContext _context;

        public IndexModel(SANoAuthFinalProj.Models.SAAppContext context)
        {
            _context = context;
        }

        public IList<DataPoint> DataPoint { get;set; }

        public async Task OnGetAsync()
        {
            DataPoint = await _context.DataPoint.ToListAsync();
        }
    }
}
