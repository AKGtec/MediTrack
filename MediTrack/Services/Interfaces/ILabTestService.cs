using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface ILabTestService
    {
        Task<LabTest?> GetLabTestByIdAsync(int labTestId);
        Task<IEnumerable<LabTest>> GetLabTestsByRecordAsync(int recordId);
        Task<LabTest> AddLabTestAsync(LabTest test);
        Task<LabTest> UpdateLabTestAsync(LabTest test);
    }
}
