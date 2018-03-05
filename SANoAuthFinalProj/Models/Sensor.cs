using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SANoAuthFinalProj.Models
{
    public class Sensor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<DataPoint> DataPoints { get; set; }

    }
}
