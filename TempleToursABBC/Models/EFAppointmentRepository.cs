using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursABBC.Models
{
    public class EFAppointmentRepository : IAppointmentRepository
    {
        private TempleDBContext context { get; set; }

        public EFAppointmentRepository (TempleDBContext temp)
        {
            context = temp;
        }

        public IQueryable<Appointment> Appointments => context.Appointments;

        public void CreateAppointment(Appointment a)
        {
            context.SaveChanges();
        }

        public void DeleteAppointment(Appointment a)
        {
            context.Add(a);
            context.SaveChanges();
        }

        public void SaveAppointment(Appointment a)
        {
            context.Remove(a);
            context.SaveChanges();
        }
    }
}
