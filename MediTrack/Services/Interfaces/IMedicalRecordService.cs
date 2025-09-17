using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<MedicalRecord?> GetRecordByIdAsync(int recordId);
        Task<IEnumerable<MedicalRecord>> GetRecordsByPatientAsync(int patientId);
        Task<MedicalRecord> CreateRecordAsync(MedicalRecord record);
        Task<MedicalRecord> UpdateRecordAsync(MedicalRecord record);
    }
}
