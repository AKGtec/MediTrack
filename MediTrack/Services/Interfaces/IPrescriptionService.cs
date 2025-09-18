using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<PrescriptionDto?> GetPrescriptionByIdAsync(int prescriptionId);
        Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByPatientAsync(int patientId);
        Task<PrescriptionDto> CreatePrescriptionAsync(CreatePrescriptionDto dto);
    }
}
