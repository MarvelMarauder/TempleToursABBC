using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleToursABBC.Models;
using TempleToursABBC.Models.ViewModels;

namespace TempleToursABBC.Controllers
{
    public class HomeController : Controller
    {
        private AppointmentContext blahContext { get; set; }

        public HomeController(AppointmentContext someName)
        {
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUpList(int pageNum = 1)
        {
            var x = new PageInfoModel
            {
                TotalNumTimes = blahContext.TimeSlots.Count(),
                TimesPerPage = 13,
                CurrentPage = pageNum
            };

            return View(x);
        }

        [HttpGet]
        public IActionResult SignUp(int timeSlotId)
        {
            ViewBag.TimeSlots = blahContext.TimeSlots.Where(x => x.TimeSlotId == timeSlotId).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                var stuff = blahContext.TimeSlots.Single(x => x.TimeSlotId == appointment.TimeSlotId);

                stuff.Available = false; // make it so the time slot is no longer available

                blahContext.Update(stuff); //updates the timeslot table

                blahContext.Add(appointment);
                blahContext.SaveChanges();

                return View("Confirmation", appointment);
            }
            else //if invalid, send back to the form and see error messages
            {
                //ViewBag.Category = blahContext.Categories.ToList();
                return View(appointment);
            }
        }
        public IActionResult ViewAppointments()
        {
            var appointments = blahContext.Appointments
               .Include(x => x.TimeSlot)
               .OrderBy(i => i.GroupName)
               .ToList();

            return View(appointments);
        }

        [HttpGet]
        public IActionResult EditAppointment(int appointmentid) //we might have to make it so when an appointment is changed, the time slot is freed up and the new appointment is not available
        {
            var appointment1 = blahContext.Appointments.Single(x => x.AppointmentId == appointmentid);
            var stuff1 = blahContext.TimeSlots.Single(x => x.TimeSlotId == appointment1.TimeSlotId);

            stuff1.Available = true; // make it so the timeslot is available when the appointment is deleted

            blahContext.Update(stuff1);
            blahContext.SaveChanges(); //free up the appointment if the appointment is changed using the edit function

            ViewBag.TimeSlots = blahContext.TimeSlots.ToList();

            var stuff = blahContext.Appointments.Single(x => x.AppointmentId == appointmentid);

            return View("SignUp", stuff);
        }

        [HttpPost]
        public IActionResult EditAppointment(Appointment appointmentStuff)
        {
            var stuff1 = blahContext.TimeSlots.Single(x => x.TimeSlotId == appointmentStuff.TimeSlotId);
            stuff1.Available = false; 

            blahContext.Update(appointmentStuff);
            blahContext.Update(stuff1);
            blahContext.SaveChanges();

            return RedirectToAction("ViewAppointments");
        }

        [HttpGet]
        public IActionResult DeleteAppointment(int appointmentid)
        {
            var to_delete = blahContext.Appointments.Single(x => x.AppointmentId == appointmentid);

            return View(to_delete);
        }

        [HttpPost]
        public IActionResult DeleteAppointment(Appointment appointment, int appointmentid)
        {
            var appointment1 = blahContext.Appointments.Single(x => x.AppointmentId == appointmentid);
            var stuff = blahContext.TimeSlots.Single(x => x.TimeSlotId == appointment1.TimeSlotId);

            stuff.Available = true; // make it so the timeslot is available when the appointment is deleted

            blahContext.Update(stuff); //updates the timeslot table

            blahContext.Appointments.Remove(appointment1);
            blahContext.SaveChanges();

            return RedirectToAction("ViewAppointments");
        }

    }
}
