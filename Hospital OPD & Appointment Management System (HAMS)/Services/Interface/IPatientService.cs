using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientReadDto>> GetAllPatient();

        Task<PatientReadDto> GetPatientById(int id);
        Task<PatientReadDto> GetPatientByName(string name);
        Task<PatientReadDto> GetPatientByEmail(string Email);
        Task<PatientReadDto> CreatePatient(PatientCreateDto xyz);
        Task<PatientReadDto> UpdatePatient(int id, PatientCreateDto xyz);
        Task<PatientReadDto> DeletePatient(int id);

    }
}
