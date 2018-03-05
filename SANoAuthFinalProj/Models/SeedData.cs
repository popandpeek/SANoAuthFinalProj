using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SANoAuthFinalProj.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SAAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<SAAppContext>>()))
            {
                // Look for any movies.
                if (context.DataPoint.Any())
                {
                    return;   // DB has been seeded
                }

                context.Sensor.AddRange(
                    new Sensor
                    {
                        Name = "FitBit",
                        DataPoints = new List<DataPoint>()
                    },
                    new Sensor
                    {
                        Name = "PillBottle",
                        DataPoints = new List<DataPoint>()
                    },
                    new Sensor
                    {
                        Name = "WeightSensor",
                        DataPoints = new List<DataPoint>()
                    },
                    new Sensor
                    {
                        Name = "DoorSensor",
                        DataPoints = new List<DataPoint>()
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

