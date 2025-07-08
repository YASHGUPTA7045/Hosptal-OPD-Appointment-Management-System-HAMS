namespace Hospital_OPD___Appointment_Management_System__HAMS_.Model
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public bool IsAvailable { get; set; }
        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
