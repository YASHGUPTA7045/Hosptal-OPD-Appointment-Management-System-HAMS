namespace Hospital_OPD___Appointment_Management_System__HAMS_.Dto
{
    public class DoctorCreateDto
    {

        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public bool IsAvailable { get; set; }
        public int DepartmentId { get; set; }
    }
}
