using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Model
{
    public class Prescription
    {


        public string Medicine { get; set; }
        public string Dosage { get; set; }
        public string Advice { get; set; }
        [Key, ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
