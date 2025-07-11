using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Model;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;
        public PatientService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PatientReadDto>> GetAllPatient()
        {
            var data = await _context.patients.Select(x => new PatientReadDto
            {
                PatientName = x.PatientName,
                PatientEmail = x.PatientEmail,
                PatientId = x.PatientId,
                PatientMobile = x.PatientMobile,

            }).ToListAsync();

            return data;
        }
        public async Task<PatientReadDto> GetPatientById(int id)
        {
            var data = await _context.patients.FirstOrDefaultAsync(x => x.PatientId == id);
            if (data == null) return null;
            var show = new PatientReadDto
            {
                PatientId = data.PatientId,
                PatientName = data.PatientName,
                PatientEmail = data.PatientEmail,
                PatientMobile = data.PatientMobile
            };
            return show;

        }
        public async Task<PatientReadDto> GetPatientByName(string name)
        {
            var data = await _context.patients.FirstOrDefaultAsync(x => x.PatientName == name);
            if (data == null) return null;
            var show = new PatientReadDto
            {
                PatientId = data.PatientId,
                PatientName = data.PatientName,
                PatientEmail = data.PatientEmail,
                PatientMobile = data.PatientMobile
            };
            return show;


        }
        public async Task<PatientReadDto> GetPatientByEmail(string Email)
        {
            var data = await _context.patients.FirstOrDefaultAsync(x => x.PatientEmail == Email);
            if (data == null) return null;
            var show = new PatientReadDto
            {
                PatientId = data.PatientId,
                PatientName = data.PatientName,
                PatientEmail = data.PatientEmail,
                PatientMobile = data.PatientMobile
            };
            return show;

        }
        public async Task<PatientReadDto> CreatePatient(PatientCreateDto xyz)
        {
            var data = new Patient
            {
                PatientName = xyz.PatientName,
                PatientEmail = xyz.PatientEmail,
                PatientMobile = xyz.PatientMobile,
            };
            await _context.patients.AddAsync(data);
            await _context.SaveChangesAsync();
            var show = new PatientReadDto
            {
                PatientId = data.PatientId,
                PatientEmail = data.PatientEmail,
                PatientMobile = data.PatientMobile,
                PatientName = data.PatientName
            };
            return show;
        }

        public async Task<PatientReadDto> UpdatePatient(int id, PatientCreateDto xyz)
        {
            var data = await _context.patients.FirstOrDefaultAsync(x => x.PatientId == id);
            if (data == null)
            {
                return null;
            }
            data.PatientName = xyz.PatientName;
            data.PatientEmail = xyz.PatientEmail;
            data.PatientMobile = xyz.PatientMobile;
            await _context.SaveChangesAsync();
            var show = new PatientReadDto
            {
                PatientId = data.PatientId,
                PatientEmail = data.PatientEmail,
                PatientMobile = data.PatientMobile,
                PatientName = data.PatientName
            };
            return show;
        }
        public async Task<PatientReadDto> DeletePatient(int id)
        {
            var data = await _context.patients.FirstOrDefaultAsync(x => x.PatientId == id);
            if (data == null) return null;
            _context.patients.Remove(data);
            await _context.SaveChangesAsync();
            var show = new PatientReadDto
            {
                PatientId = data.PatientId,
                PatientEmail = data.PatientEmail,
                PatientMobile = data.PatientMobile,
                PatientName = data.PatientName
            };
            return show;


        }
    }
}
