
using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Model;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;
        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AppointmentReadDto>> GetAllAppoint()
        {
            var data = await _context.appointments.Include(x => x.Doctor).Include(x => x.Patient)
                .Select(x => new AppointmentReadDto
                {
                    AppointmentId = x.AppointmentId,
                    AppointmentDate = x.AppointmentDate,
                    DoctorName = x.Doctor.DoctorName,
                    PatientName = x.Patient.PatientName,


                    Status = x.Status,

                }).ToListAsync();
            return data;
        }
        public async Task<AppointmentReadDto> GetAppointById(int id)
        {
            var data = await _context.appointments.Include(x => x.Patient).Include(x => x.Doctor)

                .FirstOrDefaultAsync(x => x.AppointmentId == id);
            if (data == null) return null;
            var show = new AppointmentReadDto
            {
                AppointmentId = data.AppointmentId,
                AppointmentDate = data.AppointmentDate,
                DoctorName = data.Doctor.DoctorName,
                PatientName = data.Patient.PatientName,

                Status = data.Status,
            };
            return show;
        }
        public async Task<bool> CreateAppoint(AppointmentCreateDto xyz)
        {
            var dt = xyz.AppointmentDate;
            var day = dt.DayOfWeek;
            var time = dt.TimeOfDay;

            var schedule = await _context.Schedules.Where(s => xyz.DoctorId == s.DoctorId).FirstOrDefaultAsync(d => d.Day == day);

            if (schedule == null)
            {
                return false;
            }

            if (schedule.IsOnLeave || (time < schedule.StartTime || time >= schedule.EndTime))
            {
                return false;
            }

            var isBooked = await _context.appointments.AnyAsync(x => x.AppointmentDate == xyz.AppointmentDate && x.DoctorId == xyz.DoctorId);

            if (isBooked)
            {
                return false;
            }


            var data = new Appointment
            {
                AppointmentDate = xyz.AppointmentDate,
                DoctorId = xyz.DoctorId,
                PatientId = xyz.PatientId,
                Status = "Scheduled"
            };
            await _context.appointments.AddAsync(data);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<AppointmentReadDto> UpdateAppoint(int id, AppointmentUpdateDto xyz)
        {
            var data = await _context.appointments.Include(x => x.Doctor).Include(x => x.Patient)

                .FirstOrDefaultAsync(x => x.AppointmentId == id);
            if (data == null) return null;
            data.AppointmentDate = xyz.AppointmentDate;
            data.Status = xyz.Status;
            await _context.SaveChangesAsync();


            var show = new AppointmentReadDto
            {
                AppointmentId = data.AppointmentId,
                AppointmentDate = data.AppointmentDate,
                DoctorName = data.Doctor.DoctorName,
                PatientName = data.Patient.PatientName,

                Status = data.Status
            };
            return show;
        }
        public async Task<AppointmentReadDto> DeleteAppoint(int id)
        {
            var data = await _context.appointments
       .FirstOrDefaultAsync(x => x.AppointmentId == id);
            if (data == null) return null;
            _context.appointments.Remove(data);
            await _context.SaveChangesAsync();
            var show = new AppointmentReadDto
            {
                AppointmentDate = data.AppointmentDate,
                AppointmentId = data.AppointmentId,

            };
            return show;
        }




    }
}
