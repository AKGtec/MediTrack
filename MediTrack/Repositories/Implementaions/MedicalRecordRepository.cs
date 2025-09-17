using MediTrack.Data;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Repositories.Implementaions
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly MTDbContext _context;

        public MedicalRecordRepository(MTDbContext context)
        {
            _context = context;
        }

        public async Task<MedicalRecord?> GetByIdAsync(int recordId)
        {
            return await _context.MedicalRecords
                .Include(r => r.Patient)
                .Include(r => r.Doctor)
                .Include(r => r.Appointment)
                .FirstOrDefaultAsync(r => r.RecordId == recordId);
        }

        public async Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId)
        {
            return await _context.MedicalRecords
                .Where(r => r.PatientId == patientId)
                .Include(r => r.Doctor)
                .ToListAsync();
        }

        public async Task<IEnumerable<MedicalRecord>> GetByDoctorIdAsync(int doctorId)
        {
            return await _context.MedicalRecords
                .Where(r => r.DoctorId == doctorId)
                .Include(r => r.Patient)
                .ToListAsync();
        }

        public async Task AddAsync(MedicalRecord record)
        {
            await _context.MedicalRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MedicalRecord record)
        {
            _context.MedicalRecords.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int recordId)
        {
            var record = await _context.MedicalRecords.FindAsync(recordId);
            if (record != null)
            {
                _context.MedicalRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}
