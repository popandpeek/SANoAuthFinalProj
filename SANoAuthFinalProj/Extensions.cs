using SANoAuthFinalProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SANoAuthFinalProj
{
    public static class Extensions
    {
        public static DataPoint GenerateRandomDataPoint()
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

        public static List<DataPoint> GenerateRandomDataPoints(int numberOfPoints)
        {
            if (numberOfPoints < 1)
                return null;

            List<DataPoint> dataPoints = new List<DataPoint>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                var dataPt = GenerateRandomDataPoint();
                dataPt.TimeStamp = dataPt.TimeStamp.Subtract(deltaTimeSpan * i); // Space the data points apart in time
                dataPoints.Add(dataPt);
            }

            return dataPoints;
        }

        public static object GetPropertyValue(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj);
        }

        public static List<Dictionary<string, object>> FilterProperties<T>(this IEnumerable<T> input, IEnumerable<string> properties)
        {
            return input.Select(x =>
            {
                var d = new Dictionary<string, object>();
                foreach (var p in properties)
                {
                    d[p] = x.GetPropertyValue(p);
                }
                return d;
            }).ToList();
        }

        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1);

        public static long ToUnixTime(this DateTime dateTime)
        {
            return (dateTime - UnixEpoch).Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}
