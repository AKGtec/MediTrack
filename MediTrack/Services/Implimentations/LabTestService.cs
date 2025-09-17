using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    
        public class LabTestService : ILabTestService
        {
            private readonly ILabTestRepository _labTestRepository;

            public LabTestService(ILabTestRepository labTestRepository)
            {
                _labTestRepository = labTestRepository;
            }

            public async Task<LabTest?> GetLabTestByIdAsync(int labTestId)
            {
                return await _labTestRepository.GetByIdAsync(labTestId);
            }

            public async Task<IEnumerable<LabTest>> GetLabTestsByRecordAsync(int recordId)
            {
                return await _labTestRepository.GetByRecordIdAsync(recordId);
            }

            public async Task<LabTest> AddLabTestAsync(LabTest test)
            {
                test.TestDate = DateTime.UtcNow;
                await _labTestRepository.AddAsync(test);
                return test;
            }

            public async Task<LabTest> UpdateLabTestAsync(LabTest test)
            {
                await _labTestRepository.UpdateAsync(test);
                return test;
            }
        }
    }

