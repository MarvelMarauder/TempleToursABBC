using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempleToursABBC.Models;

namespace TempleToursABBC.Components
{
    public class TimeSlotsViewComponent : ViewComponent
    {
        private AppointmentContext context { get; set; }

        public TimeSlotsViewComponent(AppointmentContext temp)
        {
            context = temp;
        }

        public IViewComponentResult Invoke()
        {
            var timeSlots = context.TimeSlots
                .Distinct()
                .OrderBy(x => x.Slot)
                .ToList();
            return View(timeSlots);
        }
    }
}
