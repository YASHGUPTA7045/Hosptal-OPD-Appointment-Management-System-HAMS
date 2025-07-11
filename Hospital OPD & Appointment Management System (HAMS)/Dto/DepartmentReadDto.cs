
namespace Hospital_OPD___Appointment_Management_System__HAMS_.Dto
{
    public class DepartmentReadDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<DoctorSummary> Doctors { get; set; }

    }
}
