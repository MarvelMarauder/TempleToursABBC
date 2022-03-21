using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursABBC.Models
{
    public class Appointment
    {
        [Required]
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public int GroupSize { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string Phone { get; set; }

        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}
