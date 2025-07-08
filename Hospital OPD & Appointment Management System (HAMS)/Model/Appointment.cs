namespace Hospital_OPD___Appointment_Management_System__HAMS_.Model
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public int PatientId { get; set; }
        public Patient Patients { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctors { get; set; }

    }
}
