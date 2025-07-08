namespace Hospital_OPD___Appointment_Management_System__HAMS_.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

    }
}
