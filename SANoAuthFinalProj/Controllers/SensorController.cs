using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SANoAuthFinalProj.Models;

namespace SANoAuthFinalProj.Controllers
{
    [Produces("application/json")]
    [Route("api/Sensor")]
    public class SensorController : Controller
    {
        private readonly SAAppContext _context;

        public SensorController(SAAppContext context)
        {
            _context = context;
        }

        // GET: api/Sensor - returns JSON serialization of all sensors
        [HttpGet]
        public IEnumerable<Sensor> GetAll()
        {
            return _context.Sensor.ToList();
        }

        // GET: api/Sensor/5
        [HttpGet("{id}", Name = "GetSensor")]
        public IActionResult GetById(int id)
        {
            var item = _context.Sensor.FirstOrDefault(t => t.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        // POST: api/Sensor
        [HttpPost]
        public IActionResult Post([FromBody]Sensor item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Sensor.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetSensor", new { id = item.ID }, item);
        }
        
        // PUT: api/Sensor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Sensor.FirstOrDefault(dt => dt.ID == id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Sensor.Remove(item);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
