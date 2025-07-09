using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentReadDto>> GetAllAsync();
        Task<DepartmentReadDto> GetByIdAsync(int id);
        Task<DepartmentReadDto> CreateAsync(DepartmentCreateDto dto);
        Task<DepartmentReadDto> UpdateAsync(int id, DepartmentUpdateDto dto);
        Task<DepartmentReadDto> DeleteAsync(int id);
    }
}
