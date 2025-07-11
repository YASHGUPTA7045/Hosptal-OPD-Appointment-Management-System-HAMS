namespace Hospital_OPD___Appointment_Management_System__HAMS_.Dto
{
    public class DoctorSummary
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public List<AppointmentSummay> Appointment { get; set; }
    }
}
