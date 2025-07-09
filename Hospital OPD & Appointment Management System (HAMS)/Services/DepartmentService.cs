using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Model;
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
            {
                return null;
            }


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
        public async Task<DepartmentReadDto> CreateAsync(DepartmentCreateDto dto)
        {
            var data = new Department
            {
                DepartmentName = dto.DepartmentName,

            };
            await _context.departments.AddAsync(data);
            await _context.SaveChangesAsync();
            var read = new DepartmentReadDto
            {
                DepartmentId = data.DepartmentId,
                DepartmentName = data.DepartmentName,
                Doctor = new List<DoctorReadDto>()


            };
            return read;
        }
        public async Task<DepartmentReadDto> UpdateAsync(int id, DepartmentUpdateDto dto)
        {
            var data = await _context.departments.Include(x => x.Doctors).FirstOrDefaultAsync(x => x.DepartmentId == id);
            if (data == null)
            {
                return null;
            }

            data.DepartmentName = dto.DepartmentName;
            await _context.SaveChangesAsync();
            var show = new DepartmentReadDto
            {
                DepartmentId = data.DepartmentId,
                DepartmentName = data.DepartmentName,

            };
            return show;
        }

        public async Task<DepartmentReadDto> DeleteAsync(int id)
        {
            var data = await _context.departments.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            _context.departments.Remove(data);
            await _context.SaveChangesAsync();
            var show = new DepartmentReadDto
            {
                DepartmentId = data.DepartmentId,
                DepartmentName = data.DepartmentName,

            };
            return show;
        }

    }
}

