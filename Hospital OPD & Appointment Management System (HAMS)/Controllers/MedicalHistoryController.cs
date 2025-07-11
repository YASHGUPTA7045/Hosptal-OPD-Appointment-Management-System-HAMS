using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMedicalHistoryService _service;
        public MedicalHistoryController(IMedicalHistoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicalHistoryByPatientId(int patientId)
        {
            var data = await _service.GetMedicalHistoryByPatientId(patientId);
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}
