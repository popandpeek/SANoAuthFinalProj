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

            var filteredDataPoints = dataPts.FilterProperties(new[]
            {
                "TimeStamp", columnName
            });
            List<Dictionary<string, object>> outputDataList = new List<Dictionary<string, object>>();

            foreach(var val in filteredDataPoints)
            {
                Dictionary<string, object> outputData = new Dictionary<string, object>();
                //long thisTimeStamp = ((DateTime)val["TimeStamp"]).ToUnixTime();
                outputData.Add("label", val["TimeStamp"]);
                outputData.Add("y", val[columnName]);
                outputDataList.Add(outputData);
                //Convert.ChangeType(val["TimeStamp"], typeof(long));
                //val["TimeStamp"] = thisTimeStamp;
            }

            var jsonOut = JsonConvert.SerializeObject(outputDataList);
            //dataPts[0].GetType().GetProperty(columnName).GetValue(dataPts[0])
            ViewBag.DataType = columnName;
            ViewBag.DataPoints = jsonOut;

            return View("~/Views/HistoricalDataView.cshtml");
        }
    }
}
