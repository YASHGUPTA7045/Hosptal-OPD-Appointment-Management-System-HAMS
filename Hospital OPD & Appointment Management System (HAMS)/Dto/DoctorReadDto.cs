﻿
namespace Hospital_OPD___Appointment_Management_System__HAMS_.Dto
{
    public class DoctorReadDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public bool IsAvailable { get; set; }
        public List<AppointmentSummay> Appointment { get; set; }


    }
}
