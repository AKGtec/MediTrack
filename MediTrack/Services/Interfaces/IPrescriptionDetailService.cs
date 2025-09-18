using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IPrescriptionDetailService
    {
        Task<IEnumerable<PrescriptionDetailDto>> GetDetailsByPrescriptionAsync(int prescriptionId);
        Task<PrescriptionDetailDto> AddDetailAsync(CreatePrescriptionDetailDto dto);
        Task<PrescriptionDetailDto?> UpdateDetailAsync(int id, UpdatePrescriptionDetailDto dto);
        Task<bool> DeleteDetailAsync(int detailId);
    }
}
