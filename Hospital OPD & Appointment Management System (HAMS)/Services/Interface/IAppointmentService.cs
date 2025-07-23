
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentReadDto>> GetAllAppoint();
        Task<AppointmentReadDto> GetAppointById(int id);
        Task<bool> CreateAppoint(AppointmentCreateDto xyz);
        Task<AppointmentReadDto> UpdateAppoint(int id, AppointmentCreateDto xyz);
        Task<AppointmentReadDto> DeleteAppoint(int id);

    }
}
