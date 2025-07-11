using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _service;
        public PrescriptionController(IPrescriptionService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetallPrescription();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var data = await _service.GetByidPrescription(id);
            if (data == null) return NotFound();
            return Ok(data);

        }
        [HttpPost]
        public async Task<IActionResult> Create(PrescriptionCreateDto xyz)
        {
            var data = await _service.CreatePrescription(xyz);
            if (data == null) return BadRequest();
            return Ok(data);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, PrescriptionUpdateDto xyz)
        {
            var data = await _service.updatePrescription(id, xyz);
            if (data == null) return BadRequest();
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.DeletePrescription(id);
            if (data == null) return BadRequest();
            return Ok(data);

        }
    }
}
