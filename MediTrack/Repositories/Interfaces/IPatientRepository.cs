using MediTrack.Models;

namespace MediTrack.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByIdAsync(int patientId);
        Task<IEnumerable<Patient>> GetAllAsync();
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int patientId);
    }
}
