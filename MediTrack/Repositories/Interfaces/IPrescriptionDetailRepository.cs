using MediTrack.Models;

namespace MediTrack.Repositories.Interfaces
{
    public interface IPrescriptionDetailRepository
    {
        Task<IEnumerable<PrescriptionDetail>> GetByPrescriptionIdAsync(int prescriptionId);
        Task AddAsync(PrescriptionDetail detail);
        Task UpdateAsync(PrescriptionDetail detail);
        Task DeleteAsync(int detailId);
        Task<PrescriptionDetail?> GetByIdAsync(int id);

    }
}
