using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursABBC.Models
{
    public class TimeSlot
    {
        [Required]
        [Key]
        public int TimeSlotId { get; set; }
        [Required]
        public DateTime Slot { get; set; }
        [Required]
        public bool Available { get; set; }
    }
}
