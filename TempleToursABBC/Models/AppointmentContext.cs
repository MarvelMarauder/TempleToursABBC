using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursABBC.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext()
        {
        }

        public AppointmentContext(DbContextOptions<AppointmentContext> options)
            : base(options)
        {
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder mb) // this is where we could do the time slot things
        {

            mb.Entity<TimeSlot>().HasData(                  // prepopulated Timeslot fields
                    new TimeSlot { TimeSlotId = 1, Slot = new DateTime(2022, 4, 15), Available = true },
                    new TimeSlot { TimeSlotId = 2, Slot = new DateTime(2022, 4, 15), Available = true },
                    new TimeSlot { TimeSlotId = 3, Slot = new DateTime(2022, 4, 15), Available = true },
                    new TimeSlot { TimeSlotId = 4, Slot = new DateTime(2022, 4, 15), Available = true }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            if (!optionsbuilder.IsConfigured)
            {
                optionsbuilder.UseSqlite("Data Source = Temple.sqlite");
            }
        }
    }
}
