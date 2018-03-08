using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SANoAuthFinalProj.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SANoAuthFinalProj.Controllers
{
    [Route("api/[controller]")]
    public class DataPointController : Controller
    {

        private readonly SAAppContext _context;

        IList DPList = new List<DataPoint>();
        public DataPointController(SAAppContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<DataPoint> GetAll()
        {
            return _context.DataPoint.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetDataPoint")]
        public IEnumerable<DataPoint> GetById(int? id)
        {
            // var List = _context.DataPoint.First(t => t.ID == id);

            return _context.DataPoint.ToList().FindAll(t => t.ID == id);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create ([FromBody] DataPoint item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.DataPoint.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetDataPoint", new { id = item.ID }, item);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
