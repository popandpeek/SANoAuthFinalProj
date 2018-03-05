using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SANoAuthFinalProj.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new SensorAppContext(serviceProvider.GetRequiredService<DbContextOptions<SensorAppContext>>()))
            //{
            //    // Look for any Sensor.
            //    if (context.Sensor.Any())
            //    {
            //        //return;   // DB has been seeded
            //    }

            //    context.Sensor.AddRange(
            //        new Sensor { ID = 1, Name = "Sensor_1" },
            //        new Sensor { ID = 2, Name = "Sensor_2" },
            //        new Sensor { ID = 3, Name = "Sensor_3" },
            //        new Sensor { ID = 4, Name = "Sensor_4" },
            //        new Sensor { ID = 5, Name = "Sensor_5" }
            //        );

            //    context.SaveChanges();
            //}

            using (var context = new SAAppContext(serviceProvider.GetRequiredService<DbContextOptions<SAAppContext>>()))
            {
                // Look for any DataPoints.
                if (context.DataPoint.Any())
                {
                    return;   // DB has already been seeded
                }

                context.DataPoint.AddRange(GenerateRandomDataPoints(20));

                context.SaveChanges();
            }
        }

        private static DataPoint GenerateRandomDataPoint()
        {
            Random rnd = new Random();

            var dataPt = new DataPoint(
                rnd.Next(1, 5),
                DateTime.Now,
                rnd.Next(100, 180),
                rnd.Next(18, 30),
                rnd.Next(100, 400),
                rnd.Next(100, 350),
                rnd.Next(100, 1000),
                rnd.Next(360, 720),
                rnd.Next(720, 1080),
                rnd.Next(10, 40),
                rnd.Next(20, 40),
                rnd.Next(100, 200),
                rnd.Next(5, 20),
                rnd.Next(5, 30),
                rnd.Next(1, 5)
                );

            return dataPt;
        }

        private static TimeSpan deltaTimeSpan = new TimeSpan(0, 5, 0); // 5 minutes

        private static List<DataPoint> GenerateRandomDataPoints(int numberOfPoints)
        {
            if (numberOfPoints < 1)
                return null;

            List<DataPoint> dataPoints = new List<DataPoint>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                var dataPt = GenerateRandomDataPoint();
                dataPt.TimeStamp.Subtract(deltaTimeSpan * i); // Space the data points apart in time
                dataPoints.Add(dataPt);
            }

            return dataPoints;
        }

        private static void ReadFromCsvFile()
        {

        }
    }
}
