using Hospital_OPD___Appointment_Management_System__HAMS_.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }
        public DbSet<DoctorSchedule> Schedules { get; set; }
        public DbSet<User> Users { get; set; }



    }
}



