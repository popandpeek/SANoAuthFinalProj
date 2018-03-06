using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SANoAuthFinalProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SANoAuthFinalProj.Controllers
{
    public class DataController : Controller
    {

        private readonly SAAppContext _context;

        public DataController(SAAppContext context)
        {
            _context = context;
        }

        public ActionResult GetData()
        {
            //var outputData = HtmlEncoder.Default.Encode($"Hello {patientName}");


            //List<DataPoint> dataPoints = new List<DataPoint>();


            //dataPoints.AddRange(Extensions.GenerateRandomDataPoints(20));
            var dataPt = Extensions.GenerateRandomDataPoint();
            ViewBag.DataPoint = JsonConvert.SerializeObject(dataPt);

            return View("~/Views/LiveDataView.cshtml");
            //return View();
        }

        //Usage Example: http://localhost:63260/Data/GetHistoricalData?columnName=BMI
        public ActionResult GetHistoricalData(string columnName)
        {
            var dataPts = _context.DataPoint.ToList();
            var f1 = dataPts.FilterProperties(new[]
            {
                "TimeStamp", columnName
            });

            var jsonOut = JsonConvert.SerializeObject(f1);
            //dataPts[0].GetType().GetProperty(columnName).GetValue(dataPts[0])

            ViewBag.DataPoints = jsonOut;

            return View("~/Views/HistoricalDataView.cshtml");
        }
    }
}
