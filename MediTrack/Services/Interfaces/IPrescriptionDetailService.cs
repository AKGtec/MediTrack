using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface IPrescriptionDetailService
    {
        Task<IEnumerable<PrescriptionDetail>> GetDetailsByPrescriptionAsync(int prescriptionId);
        Task<PrescriptionDetail> AddDetailAsync(PrescriptionDetail detail);
        Task<PrescriptionDetail> UpdateDetailAsync(PrescriptionDetail detail);
        Task<bool> DeleteDetailAsync(int detailId);
    }
}
