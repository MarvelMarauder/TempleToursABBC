using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursABBC.Models.ViewModels
{
    public class TimeSlotsViewModel
    {
        public IQueryable<TimeSlot> Times { get; set; }
        public PageInfoModel PageInfo { get; set; }

        public string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    }
}
