using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursABBC.Models
{
    public class EFTimeSlotRepository : ITimeSlotRepository
    {
        private TempleDBContext context;
        public EFTimeSlotRepository (TempleDBContext temp)
        {
            context = temp;
        }
        public IQueryable<TimeSlot> TimeSlots => context.TimeSlots; //This is where we will potentially pass the 90 day list 

        public void SaveTimeSlot(TimeSlot timeSlot)
        {
            throw new NotImplementedException();
        }
    }
}
