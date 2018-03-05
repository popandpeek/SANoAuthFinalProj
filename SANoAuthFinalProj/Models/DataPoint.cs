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
    public class DataPoint
    {

        // Constructor for creating dummy points if needed.
        public DataPoint(int id, DateTime timeStamp, double weight, double bmi, int caloriesIn, int caloriesBurned, int steps, int minutesAsleep, int minutesAwake, int fatConsumed, int fiberConsumed, int carbsConsumed, int sodiumConsumed, int proteinConsumed, int waterConsumed)
        {
            this.ID = id;
            this.TimeStamp = timeStamp;
            this.Weight = weight;
            this.BMI = bmi;
            this.CaloriesIn = caloriesIn;
            this.CaloriesBurned = caloriesBurned;
            this.Steps = steps;
            this.MinutesAsleep = minutesAsleep;
            this.MinutesAwake = minutesAwake;
            // Grams
            this.FatConsumed = fatConsumed;
            // Grams
            this.FiberConsumed = fiberConsumed;
            // Grams
            this.CarbsConsumed = carbsConsumed;
            // Milligrams 
            this.SodiumConsumed = sodiumConsumed;
            // Grams
            this.ProteinConsumed = proteinConsumed;
            // Fluid ounces
            this.WaterConsumed = waterConsumed;
        }

        public DataPoint()
        {
            // Default constructor
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("ID")]
        public int ID { get; set; }
        [Key]
        public DateTime TimeStamp { get; set; }
        [DataMember]
        public double Weight { get; set; }
        [DataMember]
        public double BMI { get; set; }
        [DataMember]
        public int CaloriesIn { get; set; }
        [DataMember]
        public int CaloriesBurned { get; set; }
        [DataMember]
        public int Steps { get; set; }
        [DataMember]
        public int MinutesAsleep { get; set; }
        [DataMember]
        public int MinutesAwake { get; set; }
        [DataMember]
        // Grams
        public int FatConsumed { get; set; }
        [DataMember]
        // Grams
        public int FiberConsumed { get; set; }
        [DataMember]
        // Grams
        public int CarbsConsumed { get; set; }
        [DataMember]
        // Milligrams 
        public int SodiumConsumed { get; set; }
        [DataMember]
        // Grams
        public int ProteinConsumed { get; set; }
        [DataMember]
        // Fluid ounces
        public int WaterConsumed { get; set; }
    }
}
