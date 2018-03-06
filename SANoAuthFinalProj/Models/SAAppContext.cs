using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SANoAuthFinalProj.Models
{
    public class SAAppContext : DbContext
    {
        public SAAppContext(DbContextOptions<SAAppContext> options) 
            : base(options)
        {
        }

        public DbSet<Sensor> Sensor { get; set; }
        public DbSet<DataPoint> DataPoint { get; set; }

        internal Task Find(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
