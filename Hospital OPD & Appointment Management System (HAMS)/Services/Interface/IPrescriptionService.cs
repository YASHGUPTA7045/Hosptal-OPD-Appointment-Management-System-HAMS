using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionReadDto>> GetallPrescription();
        Task<PrescriptionReadDto> GetByidPrescription(int id);
        Task<PrescriptionReadDto> CreatePrescription(PrescriptionCreateDto xyz);
        Task<PrescriptionReadDto> updatePrescription(int id, PrescriptionUpdateDto xyz);
        Task<PrescriptionReadDto> DeletePrescription(int id);
    }
}
