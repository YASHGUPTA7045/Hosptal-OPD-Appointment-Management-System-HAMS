
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
        private readonly IEmailServices _emailservices;
        public AppointmentService(AppDbContext context, IEmailServices emailServices)
        {
            _context = context;
            _emailservices = emailServices;
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


                    Reason = x.Status,

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

                Reason = data.Status,
            };
            return show;
        }
        public async Task<bool> CreateAppoint(AppointmentCreateDto dto)
        {
            var date = dto.AppointmentDate;
            var day = date.DayOfWeek;
            var time = date.TimeOfDay;

            var schedule = await _context.Schedules.Where(s => dto.DoctorId == s.DoctorId).FirstOrDefaultAsync(d => d.Day == day);

            if (schedule == null || schedule.IsOnLeave || (time < schedule.StartTime || time >= schedule.EndTime))
            {
                return false;
            }

            var isBooked = await _context.appointments.AnyAsync(x => x.AppointmentDate == dto.AppointmentDate && x.DoctorId == dto.DoctorId);

            if (isBooked)
            {
                return false;
            }


            var appointment = new Appointment
            {
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                AppointmentDate = dto.AppointmentDate,
                Status = dto.Reason
            };
            await _context.appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();

            var patient = await _context.patients.FindAsync(appointment.PatientId);
            var doctor = await _context.doctors.FindAsync(appointment.DoctorId);
            await _emailservices.SendEmailAsync(
                patient.PatientEmail,
                "Appointment Confirmation",
                $"Your appointment is confirmed with  {doctor.DoctorName} at {appointment.AppointmentDate}.\n");

            return true;
        }

        public async Task<AppointmentReadDto> UpdateAppoint(int id, AppointmentCreateDto xyz)
        {
            var data = await _context.appointments
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .FirstOrDefaultAsync(x => x.AppointmentId == id);

            if (data == null) return null;


            var dt = xyz.AppointmentDate;
            var day = dt.DayOfWeek;
            var time = dt.TimeOfDay;

            var schedule = await _context.Schedules
                .Where(s => s.DoctorId == s.DoctorId)
                .FirstOrDefaultAsync(d => d.Day == day);

            if (schedule == null)
                return null;

            if (schedule.IsOnLeave || (time < schedule.StartTime || time >= schedule.EndTime))
                return null;


            var isBooked = await _context.appointments
                .AnyAsync(x => x.AppointmentDate == xyz.AppointmentDate
                            && x.DoctorId == xyz.DoctorId
                            && x.AppointmentId != id);

            if (isBooked)
                return null;

            data.AppointmentDate = xyz.AppointmentDate;
            data.Status = xyz.Reason;
            data.DoctorId = xyz.DoctorId;
            data.PatientId = xyz.PatientId;


            await _context.SaveChangesAsync();

            // Return DTO
            var show = new AppointmentReadDto
            {
                AppointmentId = data.AppointmentId,
                AppointmentDate = data.AppointmentDate,
                DoctorName = data.Doctor.DoctorName,
                PatientName = data.Patient.PatientName,
                Reason = data.Status
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
                DoctorName = data.Doctor.DoctorName,
                PatientName = data.Patient.PatientName,
                Reason = data.Status,
            };
            return show;
        }




    }
}
