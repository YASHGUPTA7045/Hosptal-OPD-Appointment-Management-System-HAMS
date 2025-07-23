using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface
{
    public interface IAuthServices
    {

        Task<string> Register(UserLoginDto dto);
        Task<string> Login(UserLoginDto dto);


    }
}
