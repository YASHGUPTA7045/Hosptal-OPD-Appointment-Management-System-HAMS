using System.ComponentModel.DataAnnotations;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Model
{
    public class DoctorSchedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsOnLeave { get; set; } = false;


    }
}
