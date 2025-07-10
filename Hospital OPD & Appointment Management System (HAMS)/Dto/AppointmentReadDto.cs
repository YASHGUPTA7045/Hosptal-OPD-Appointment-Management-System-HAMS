namespace Hospital_OPD___Appointment_Management_System__HAMS_.Dto
{
    public class AppointmentReadDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
