using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly AppDbContext _context;
        public MedicalHistoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MedicalHistoryReadDto>> GetMedicalHistoryByPatientId(int patientId)
        {
            var appointments = await _context.appointments
                .Where(a => a.PatientId == patientId)
                .Include(a => a.Doctor)
                .Include(a => a.Prescription)
                .ToListAsync();

            var data = appointments.Select(a => new MedicalHistoryReadDto
            {
                AppointmentId = a.AppointmentId,
                AppointmentDate = a.AppointmentDate,
                Doctor = new DoctorSummary
                {
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor.DoctorName,
                },
                Medicine = a.Prescription?.Medicine ?? "N/A",
                Dosage = a.Prescription?.Dosage ?? "N/A",
                Advice = a.Prescription?.Advice ?? "N/A"
            }).ToList();

            return data;
        }




    }
}
