
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAppoint();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getbyid(int id)
        {
            var data = await _service.GetAppointById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppointmentCreateDto xyz)
        {
            var data = await _service.CreateAppoint(xyz);
            return Ok(data);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AppointmentCreateDto xyz)
        {
            var data = await _service.UpdateAppoint(id, xyz);
            if (data == null) return NotFound();
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var data = await _service.DeleteAppoint(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

    }
}
