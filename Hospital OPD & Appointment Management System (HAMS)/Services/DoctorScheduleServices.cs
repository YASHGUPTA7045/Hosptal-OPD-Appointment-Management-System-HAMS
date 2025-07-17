using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Model;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class DoctorScheduleServices : IDoctorSchedule
    {
        private readonly AppDbContext _context;
        public DoctorScheduleServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ScheduleDoctor(DoctorScheduleDto dto)
        {


            var data = new DoctorSchedule
            {
                Day = dto.Day,
                DoctorId = dto.DoctorId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                IsOnLeave = dto.IsOnLeave,
            };
            await _context.Schedules.AddAsync(data);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<ScheduleDoctorReadDto>> ScheduleDoctorRead()
        {
            var data = await _context.Schedules.Select(x => new ScheduleDoctorReadDto
            {
                Day = x.Day,
                DoctorId = x.DoctorId,
                ScheduleId = x.ScheduleId,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                IsOnLeave = x.IsOnLeave
            }).ToListAsync();
            if (data == null) return null;

            return data;
        }
        public async Task<ScheduleDoctorReadDto> ScheduleDoctorById(int id)
        {
            var data = await _context.Schedules.FirstOrDefaultAsync(x => x.ScheduleId == id);
            if (data == null) return null;
            var show = new ScheduleDoctorReadDto
            {
                Day = data.Day,
                DoctorId = data.DoctorId,
                ScheduleId = data.ScheduleId,
                StartTime = data.StartTime,
                EndTime = data.EndTime,
                IsOnLeave = data.IsOnLeave

            };
            return show;
        }
        public async Task<ScheduleDoctorReadDto> ScheduleDoctorUpdate(int id, DoctorScheduleDto dto)
        {
            var data = await _context.Schedules.FirstOrDefaultAsync(x => x.ScheduleId == id);
            if (data == null) return null;
            data.Day = dto.Day;
            data.DoctorId = dto.DoctorId;
            data.StartTime = dto.StartTime;
            data.EndTime = dto.EndTime;
            data.IsOnLeave = dto.IsOnLeave;
            await _context.SaveChangesAsync();
            var show = new ScheduleDoctorReadDto
            {
                Day = data.Day,
                DoctorId = data.DoctorId,
                ScheduleId = data.ScheduleId,
                StartTime = data.StartTime,
                EndTime = data.EndTime,
                IsOnLeave = data.IsOnLeave
            };
            return show;

        }
        public async Task<bool> ScheduleDoctorDelete(int id)
        {
            var data = await _context.Schedules.FirstOrDefaultAsync(x => x.ScheduleId == id);
            if (data == null) return false;
            _context.Schedules.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }





}

