using MediTrack.Models;

namespace MediTrack.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<Doctor?> GetByIdAsync(int doctorId);
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization);
        Task AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(int doctorId);
    }
}
