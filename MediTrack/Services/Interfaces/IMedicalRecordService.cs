using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<MedicalRecordDto?> GetRecordByIdAsync(int recordId);
        Task<IEnumerable<MedicalRecordDto>> GetRecordsByPatientAsync(int patientId);
        Task<MedicalRecordDto> CreateRecordAsync(CreateMedicalRecordDto dto);
        Task<MedicalRecordDto?> UpdateRecordAsync(int id, UpdateMedicalRecordDto dto);
    }
}
