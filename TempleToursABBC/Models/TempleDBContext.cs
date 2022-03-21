using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursABBC.Models
{
    public class TempleDBContext : DbContext
    {
        public TempleDBContext()
        {
        }

        public TempleDBContext(DbContextOptions<TempleDBContext> options)
            : base(options)
        {
        }

        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            if (!optionsbuilder.IsConfigured)
            {
                optionsbuilder.UseSqlite("Data Source = Temple.sqlite");
            }
        }
    }
}
