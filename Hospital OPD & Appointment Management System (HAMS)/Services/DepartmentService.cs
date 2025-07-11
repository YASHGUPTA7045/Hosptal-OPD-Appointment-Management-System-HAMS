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
            var data = await _context.departments
                .Include(x => x.Doctors)
                .ThenInclude(d => d.Appointments)
                .Select(x => new DepartmentReadDto
                {
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.DepartmentName,
                    Doctors = x.Doctors.Select(d => new DoctorSummary
                    {
                        DoctorId = d.DoctorId,
                        DoctorName = d.DoctorName,


                        Appointment = d.Appointments.Select(x => new AppointmentSummay
                        {
                            AppointmentId = x.AppointmentId,
                            AppointmentDate = x.AppointmentDate,
                            Status = x.Status


                        }).ToList()
                    }).ToList()
                }).ToListAsync();

            return data;
        }

        public async Task<DepartmentReadDto> GetByIdAsync(int id)
        {
            var dept = await _context.departments.Include(X => X.Doctors).ThenInclude(x => x.Appointments)

                .FirstOrDefaultAsync(x => x.DepartmentId == id);

            if (dept == null)
            {
                return null;
            }


            var s = new DepartmentReadDto
            {
                DepartmentId = dept.DepartmentId,
                DepartmentName = dept.DepartmentName,
                Doctors = dept.Doctors.Select(x => new DoctorSummary
                {
                    DoctorId = x.DoctorId,
                    DoctorName = x.DoctorName,
                    Appointment = x.Appointments.Select(y => new AppointmentSummay
                    {
                        AppointmentDate = y.AppointmentDate,
                        AppointmentId = y.AppointmentId,
                        Status = y.Status
                    }).ToList()
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



            };
            return read;
        }
        public async Task<DepartmentReadDto> UpdateAsync(int id, DepartmentUpdateDto dto)
        {
            var data = await _context.departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
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

