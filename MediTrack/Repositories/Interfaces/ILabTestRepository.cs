using MediTrack.Models;

namespace MediTrack.Repositories.Interfaces
{
    public interface ILabTestRepository
    {
        Task<LabTest?> GetByIdAsync(int labTestId);
        Task<IEnumerable<LabTest>> GetByRecordIdAsync(int recordId);
        Task AddAsync(LabTest test);
        Task UpdateAsync(LabTest test);
        Task DeleteAsync(int labTestId);
    }
}
