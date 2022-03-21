using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursABBC.Models
{
    public interface IAppointmentRepository
    {
        IQueryable<Appointment> Appointments { get; }

        public void SaveAppointment(Appointment a);
        public void CreateAppointment(Appointment a);
        public void DeleteAppointment(Appointment a);

    }
}
