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

            // Finds the Sensor that matches the foreign key ID in the DataPoint
            var findSensorByID = _context.Sensor.Single(s => s.ID == DataPoint.ID);

            // Add DataPoint to the list of the sensor
            findSensorByID.DataPoints.Add(DataPoint);

            // added commands to unlock/lock permissions to set ID params
            //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.DataPoint ON");
            await _context.SaveChangesAsync();
            //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.DataPoint OFF");

            return RedirectToPage("./Index");
        }
    }
}