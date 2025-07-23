using System.ComponentModel.DataAnnotations;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Model
{
    public class EmailSetting
    {

        [Key]
        public string FromEmail { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
