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
                // if db contains any sesnors, 
                if (context.Sensor.Any() == false)
                {

                    context.Sensor.AddRange(
                        new Sensor
                        {
                            Name = "FitBit",
                            ID = 1,
                            DataPoints = new List<DataPoint>()
                        },
                        new Sensor
                        {
                            Name = "PillBottle",
                            ID = 2,
                            DataPoints = new List<DataPoint>()
                        },
                        new Sensor
                        {
                            Name = "WeightSensor",
                            ID = 3,
                            DataPoints = new List<DataPoint>()
                        },
                        new Sensor
                        {
                            Name = "DoorSensor1",
                            ID = 4,
                            DataPoints = new List<DataPoint>()
                        },
                        new Sensor
                        {
                            Name = "DoorSensor2",
                            ID = 5,
                            DataPoints = new List<DataPoint>()
                        }
                    );

                    context.SaveChanges();
                }

                // If Datapoints already exist, don't add any
                if (context.DataPoint.Any() == false)
                {

                    context.DataPoint.AddRange(Extensions.GenerateRandomDataPoints(20));

                    context.SaveChanges();
                }
            }
        }

        private static void ReadFromCsvFile()
        {

        }
    }
}

