using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Patient?> GetPatientByIdAsync(int patientId);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> CreatePatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task<bool> DeletePatientAsync(int patientId);
    }
}
