using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Dto;
using Hospital_OPD___Appointment_Management_System__HAMS_.Model;

using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class PrescriptionServices : IPrescriptionService
    {
        private readonly AppDbContext _context;
        public PrescriptionServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PrescriptionReadDto>> GetallPrescription()
        {
            var data = await _context.prescriptions.Select(x => new PrescriptionReadDto
            {
                AppointmentId = x.AppointmentId,
                Advice = x.Advice,
                Dosage = x.Dosage,
                Medicine = x.Medicine
            }).ToListAsync();
            return data;
        }
        public async Task<PrescriptionReadDto> GetByidPrescription(int id)
        {
            var data = await _context.prescriptions.FindAsync(id);
            if (data == null) return null;
            var show = new PrescriptionReadDto
            {
                AppointmentId = data.AppointmentId,
                Advice = data.Advice,
                Dosage = data.Dosage,
                Medicine = data.Medicine
            };
            return show;

        }
        public async Task<PrescriptionReadDto> CreatePrescription(PrescriptionCreateDto xyz)
        {
            var data = new Prescription
            {
                Advice = xyz.Advice,
                Dosage = xyz.Dosage,
                Medicine = xyz.Medicine,
                AppointmentId = xyz.AppointmentId
            };
            await _context.prescriptions.AddAsync(data);
            await _context.SaveChangesAsync();
            var show = new PrescriptionReadDto
            {
                Advice = data.Advice,
                AppointmentId = data.AppointmentId,


                Medicine = data.Medicine,
                Dosage = data.Dosage
            };
            return show;

        }
        public async Task<PrescriptionReadDto> updatePrescription(int id, PrescriptionUpdateDto xyz)
        {
            var data = await _context.prescriptions.FirstOrDefaultAsync(x => x.AppointmentId == id);
            data.Medicine = xyz.Medicine;
            data.Advice = xyz.Advice;
            data.Dosage = xyz.Dosage;
            await _context.SaveChangesAsync();
            var show = new PrescriptionReadDto
            {
                AppointmentId = data.AppointmentId,
                Advice = data.Advice,
                Medicine = data.Medicine,
                Dosage = data.Dosage,

            };
            return show;
        }
        public async Task<PrescriptionReadDto> DeletePrescription(int id)
        {
            var data = await _context.prescriptions.FindAsync(id);

            if (data == null) return null;
            _context.prescriptions.Remove(data);
            await _context.SaveChangesAsync();
            return new PrescriptionReadDto
            {
                AppointmentId = data.AppointmentId,
                Medicine = data.Medicine,
                Advice = data.Advice,
                Dosage = data.Dosage
            };
        }
    }
}
