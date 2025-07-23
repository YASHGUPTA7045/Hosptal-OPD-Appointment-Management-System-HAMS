using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDailyAppointmentCount _service;
        public DashboardController(IDailyAppointmentCount service)
        {
            _service = service;

        }
        [HttpGet("daily-count-by-doctor")]
        public async Task<IActionResult> GetDailyAppointmentCountByDoctor([FromQuery] DateTime date)
        {
            var result = await _service.GetDailyAppointmentCountByDoctor(date);
            return Ok(result);
        }

    }
}
