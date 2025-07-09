using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllDoctor();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getbyid(int id)
        {
            var data = await _service.GetDoctorById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorCreateDto xyz)
        {
            var data = await _service.CreateDoctor(xyz);
            return Ok(data);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DoctorUpdateDto xyz)
        {
            var data = await _service.UpdateDoctor(id, xyz);
            if (data == null) return NotFound();
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var data = await _service.DeleteDoctor(id);
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}
