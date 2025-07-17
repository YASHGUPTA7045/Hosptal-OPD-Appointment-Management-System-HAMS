using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface
{
    public interface IDoctorSchedule
    {
        Task<bool> ScheduleDoctor(DoctorScheduleDto dto);
        Task<IEnumerable<ScheduleDoctorReadDto>> ScheduleDoctorRead();
        Task<ScheduleDoctorReadDto> ScheduleDoctorById(int id);
        Task<ScheduleDoctorReadDto> ScheduleDoctorUpdate(int id, DoctorScheduleDto dto);
        Task<bool> ScheduleDoctorDelete(int id);

    }
}
