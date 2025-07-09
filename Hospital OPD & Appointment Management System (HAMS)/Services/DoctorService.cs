using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Model;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.EntityFrameworkCore;


namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;
        public DoctorService(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<DoctorReadDto>> GetAllDoctor()
        {
            var data = await _context.doctors.Include(x => x.Departments).Select(x => new DoctorReadDto
            {
                DoctorId = x.DoctorId,
                DoctorName = x.DoctorName,
                IsAvailable = x.IsAvailable,
                Specialization = x.Specialization,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Departments.DepartmentName
            }).ToListAsync();
            return data;

        }
        public async Task<DoctorReadDto> GetDoctorById(int id)
        {
            var data = await _context.doctors.Include(x => x.Departments).FirstOrDefaultAsync(x => x.DoctorId == id);
            if (data == null)
            {
                return null;
            }
            var show = new DoctorReadDto
            {
                DoctorId = data.DoctorId,
                DoctorName = data.DoctorName,
                Specialization = data.Specialization,
                IsAvailable = data.IsAvailable,
                DepartmentId = data.DepartmentId,
                DepartmentName = data.Departments.DepartmentName
            };
            return show;
        }
        public async Task<DoctorReadDto> CreateDoctor(DoctorCreateDto xyz)
        {
            var data = new Doctor
            {
                DoctorName = xyz.DoctorName,
                Specialization = xyz.Specialization,
                IsAvailable = xyz.IsAvailable
            };
            await _context.doctors.AddAsync(data);
            await _context.SaveChangesAsync();
            var show = new DoctorReadDto
            {
                DoctorId = data.DoctorId,
                DoctorName = data.DoctorName,
                Specialization = data.DoctorName,
                IsAvailable = data.IsAvailable
            };
            return show;


        }
        public async Task<DoctorReadDto> UpdateDoctor(int id, DoctorUpdateDto xyz)
        {
            var data = await _context.doctors.Include(x => x.Departments).FirstOrDefaultAsync(x => x.DoctorId == id);
            if (data == null) return null;
            data.DoctorName = xyz.DoctorName;
            data.Specialization = xyz.Specialization;
            data.IsAvailable = xyz.IsAvailable;
            data.DepartmentId = xyz.DepartmentId;
            await _context.SaveChangesAsync();

            var show = new DoctorReadDto
            {
                DoctorId = data.DoctorId,
                DoctorName = data.DoctorName,
                Specialization = data.Specialization,
                IsAvailable = data.IsAvailable,
                DepartmentId = data.DepartmentId,
                DepartmentName = data.Departments?.DepartmentName
            };
            return show;


        }
        public async Task<DoctorReadDto> DeleteDoctor(int id)
        {
            var data = await _context.doctors.FindAsync(id);
            if (data == null) return null;
            _context.doctors.Remove(data);
            await _context.SaveChangesAsync();
            var show = new DoctorReadDto
            {
                DoctorId = data.DoctorId,
                DoctorName = data.DoctorName,
                DepartmentId = data.DepartmentId,
                DepartmentName = data.Departments.DepartmentName,


            };
            return show;
        }
    }
}
