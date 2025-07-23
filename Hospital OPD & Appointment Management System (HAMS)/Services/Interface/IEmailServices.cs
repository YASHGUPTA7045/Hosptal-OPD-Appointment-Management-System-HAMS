namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface
{
    public interface IEmailServices
    {
        Task SendEmailAsync(String toEmail, string subject, string body);
    }
}
