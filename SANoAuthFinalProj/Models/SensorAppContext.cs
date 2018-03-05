using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SANoAuthFinalProj.Models
{
    public class SensorAppContext : DbContext
    {
        public SensorAppContext(DbContextOptions<SensorAppContext> options)
            : base(options)
        {
        }

        public DbSet<Sensor> Sensor { get; set; }
    }
}