using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SANoAuthFinalProj.Models
{
    [DataContract] // JSON Serialization
    public class Sensor
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [DataMember]
        [Required]
        public string Name { get; set; }
        public ICollection<DataPoint> DataPoints { get; set; }

    }
}
