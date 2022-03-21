using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursABBC.Models
{
    public interface ITimeSlotRepository
    {
        IQueryable<TimeSlot> TimeSlots { get; }

        void SaveTimeSlot(TimeSlot timeSlot);
    }
}
