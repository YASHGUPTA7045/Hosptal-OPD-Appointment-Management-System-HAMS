using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorSchedule _service;
        public DoctorScheduleController(IDoctorSchedule service)
        {
            _service = service;

        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorScheduleDto xyz)
        {
            var data = await _service.ScheduleDoctor(xyz);
            if (data == null) return BadRequest();
            return Ok(data);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.ScheduleDoctorRead();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getbyid(int id)
        {
            var data = await _service.ScheduleDoctorById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DoctorScheduleDto xyz)
        {
            var data = await _service.ScheduleDoctorUpdate(id, xyz);
            if (data == null) return NotFound();
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var data = await _service.ScheduleDoctorDelete(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

    }
}