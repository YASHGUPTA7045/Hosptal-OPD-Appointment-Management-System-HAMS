namespace Hospital_OPD___Appointment_Management_System__HAMS_.Model
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string PatientMobile { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
