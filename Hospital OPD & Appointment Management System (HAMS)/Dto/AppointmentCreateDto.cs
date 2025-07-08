namespace Hospital_OPD___Appointment_Management_System__HAMS_.Dto
{
    public class AppointmentCreateDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

    }
}
