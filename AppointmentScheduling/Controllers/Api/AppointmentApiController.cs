using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduling.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using AppointmentScheduling.Models.ViewModels;
using AppointmentScheduling.Utility;

namespace AppointmentScheduling.Controllers.Api
{

    [Route("api/Appointment")]


    //api endpoint
    [ApiController]
    public class AppointmentApiController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;

        private readonly string role;


        public AppointmentApiController(IAppointmentService appointmentService,IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        }
        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(AppointmentVM data )
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.Status = _appointmentService.AddUpdate(data).Result;
                if (commonResponse.Status ==1 )
                {
                    //update
                    commonResponse.Message = Helper.appointmentUpdated;
                }
                else
                {
                    //create
                    commonResponse.Message = Helper.appointmentAdded;
                }

            }
            catch (Exception e)
            {

                commonResponse.Message = e.Message;

                commonResponse.Status = Helper.failure_code;
            }

            return View();
        }
    }
}
