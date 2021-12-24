using AppointmentScheduling.Services;
using AppointmentScheduling.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Controllers
{
    public class AppointmentController : Controller
    {

        //private readonly IAppointmentService _appointmentService;
        //public AppointmentController(IAppointmentService appointmentService)
        //{
        //    _appointmentService = appointmentService;
        //}

        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            //_appointmentService.GetDoctorList();


          ViewBag.DoctorList=  _appointmentService.GetDoctorList();
            ViewBag.PatientList = _appointmentService.GetPatientList();

            ViewBag.Duration = Helper.GetTimeDropDown();
            return View();
        }
    }
}
