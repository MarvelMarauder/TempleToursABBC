using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleToursABBC.Models;

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
        public IActionResult SignUp()
        {
            ViewBag.TimeSlots = blahContext.TimeSlots.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
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
        public IActionResult EditAppointment(int appointmentid)
        {
            ViewBag.TimeSlots = blahContext.TimeSlots.ToList();

            var stuff = blahContext.Appointments.Single(x => x.AppointmentId == appointmentid);

            return View("SignUp", stuff);
        }

        [HttpPost]
        public IActionResult EditAppointment(Appointment appointmentStuff)
        {
            blahContext.Update(appointmentStuff);
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
        public IActionResult DeleteAppointment(Appointment appointment)
        {
            blahContext.Appointments.Remove(appointment);
            blahContext.SaveChanges();

            return RedirectToAction("ViewAppointments");
        }

    }
}
