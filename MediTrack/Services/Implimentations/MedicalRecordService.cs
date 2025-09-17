using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<MedicalRecord?> GetRecordByIdAsync(int recordId)
        {
            return await _medicalRecordRepository.GetByIdAsync(recordId);
        }

        public async Task<IEnumerable<MedicalRecord>> GetRecordsByPatientAsync(int patientId)
        {
            return await _medicalRecordRepository.GetByPatientIdAsync(patientId);
        }

        public async Task<MedicalRecord> CreateRecordAsync(MedicalRecord record)
        {
            record.CreatedAt = DateTime.UtcNow;
            await _medicalRecordRepository.AddAsync(record);
            return record;
        }

        public async Task<MedicalRecord> UpdateRecordAsync(MedicalRecord record)
        {
            await _medicalRecordRepository.UpdateAsync(record);
            return record;
        }
    }
}
