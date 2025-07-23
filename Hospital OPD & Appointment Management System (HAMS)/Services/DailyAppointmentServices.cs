using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{


    public class DailyAppointmentServices : IDailyAppointmentCount
    {
        private readonly AppDbContext _context;
        public DailyAppointmentServices(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<DailyAppointmentCountDto>> GetDailyAppointmentCountByDoctor(DateTime date)
        {
            var result = await _context.appointments
                .Where(a => a.AppointmentDate.Date == date.Date)
                .GroupBy(a => new { a.DoctorId, a.Doctor.DoctorName })
                .Select(g => new DailyAppointmentCountDto
                {
                    DoctorId = g.Key.DoctorId,
                    DoctorName = g.Key.DoctorName,
                    AppointmentCount = g.Count()
                })
                .ToListAsync();

            return result;
        }


    }
}
