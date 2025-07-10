using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;
        public PatientController(IPatientService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllPatient();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getbyid(int id)
        {
            var data = await _service.GetPatientById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PatientCreateDto xyz)
        {
            var data = await _service.CreatePatient(xyz);
            return Ok(data);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatientCreateDto xyz)
        {
            var data = await _service.UpdatePatient(id, xyz);
            if (data == null) return NotFound();
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var data = await _service.DeletePatient(id);
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}
