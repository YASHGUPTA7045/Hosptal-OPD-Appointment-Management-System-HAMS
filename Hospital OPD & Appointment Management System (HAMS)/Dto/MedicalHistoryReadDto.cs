namespace Hospital_OPD___Appointment_Management_System__HAMS_.Dto
{
    public class MedicalHistoryReadDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public DoctorSummaryDto Doctor { get; set; }

        public string Medicine { get; set; }
        public string Dosage { get; set; }
        public string Advice { get; set; }

    }
}
