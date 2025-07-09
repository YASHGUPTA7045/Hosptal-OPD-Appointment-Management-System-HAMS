using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface
{
    public interface IDoctorService
    {


        Task<IEnumerable<DoctorReadDto>> GetAllDoctor();
        Task<DoctorReadDto> GetDoctorById(int id);
        Task<DoctorReadDto> CreateDoctor(DoctorCreateDto xyz);
        Task<DoctorReadDto> UpdateDoctor(int id, DoctorUpdateDto xyz);
        Task<DoctorReadDto> DeleteDoctor(int id);
    }
}
