using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DepartmentReadDto>> GetAllAsync()
        {
            var data = await _context.departments.Include(x => x.Doctors).Select(x => new DepartmentReadDto
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                Doctor = x.Doctors.Select(x => new DoctorReadDto
                {
                    DoctorId = x.DoctorId,
                    DoctorName = x.DoctorName,
                    IsAvailable = x.IsAvailable,
                    Specialization = x.Specialization
                })

            }).ToListAsync();
            return data;
        }

        public async Task<DepartmentReadDto> GetByIdAsync(int id)
        {
            var dept = await _context.departments
                .Include(x => x.Doctors)
                .FirstOrDefaultAsync(x => x.DepartmentId == id);

            if (dept == null)
                return null;

            var s = new DepartmentReadDto
            {
                DepartmentId = dept.DepartmentId,
                DepartmentName = dept.DepartmentName,
                Doctor = dept.Doctors.Select(x => new DoctorReadDto
                {
                    DoctorId = x.DoctorId,
                    DoctorName = x.DoctorName,
                    IsAvailable = x.IsAvailable,
                    Specialization = x.Specialization
                }).ToList()
            };
            return s;
        }

    }
}

