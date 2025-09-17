using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class PrescriptionDetailService : IPrescriptionDetailService
    {
        private readonly IPrescriptionDetailRepository _prescriptionDetailRepository;

        public PrescriptionDetailService(IPrescriptionDetailRepository prescriptionDetailRepository)
        {
            _prescriptionDetailRepository = prescriptionDetailRepository;
        }

        public async Task<IEnumerable<PrescriptionDetail>> GetDetailsByPrescriptionAsync(int prescriptionId)
        {
            return await _prescriptionDetailRepository.GetByPrescriptionIdAsync(prescriptionId);
        }

        public async Task<PrescriptionDetail> AddDetailAsync(PrescriptionDetail detail)
        {
            await _prescriptionDetailRepository.AddAsync(detail);
            return detail;
        }

        public async Task<PrescriptionDetail> UpdateDetailAsync(PrescriptionDetail detail)
        {
            await _prescriptionDetailRepository.UpdateAsync(detail);
            return detail;
        }

        public async Task<bool> DeleteDetailAsync(int detailId)
        {
            await _prescriptionDetailRepository.DeleteAsync(detailId);
            return true;
        }
    }
}
