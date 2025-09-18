using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface ILabTestService
    {
        Task<LabTestDto?> GetLabTestByIdAsync(int labTestId);
        Task<IEnumerable<LabTestDto>> GetLabTestsByRecordAsync(int recordId);
        Task<LabTestDto> AddLabTestAsync(CreateLabTestDto dto);
        Task<LabTestDto?> UpdateLabTestAsync(int id, UpdateLabTestDto dto);
    }
}
