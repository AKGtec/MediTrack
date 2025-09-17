using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<Prescription?> GetPrescriptionByIdAsync(int prescriptionId);
        Task<IEnumerable<Prescription>> GetPrescriptionsByPatientAsync(int patientId);
        Task<Prescription> CreatePrescriptionAsync(Prescription prescription);
    }
}
