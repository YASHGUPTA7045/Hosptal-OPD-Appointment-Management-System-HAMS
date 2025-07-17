using System.ComponentModel.DataAnnotations;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Dto
{
    public class DoctorScheduleDto
    {
        [Key]

        public int DoctorId { get; set; }

        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsOnLeave { get; set; } = false;
    }
}
