using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);

        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateDto xyz)
        {
            var data = await _service.CreateAsync(xyz);
            if (data == null) return BadRequest();
            return Ok(data);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, DepartmentUpdateDto xyz)
        {
            var data = await _service.UpdateAsync(id, xyz);
            if (data == null) return BadRequest();
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.DeleteAsync(id);
            if (data == null) return BadRequest();
            return Ok(data);

        }



    }
}
