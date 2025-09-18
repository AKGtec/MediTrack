using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class LabTestService : ILabTestService
    {
        private readonly ILabTestRepository _labTestRepository;
        private readonly IMapper _mapper;

        public LabTestService(ILabTestRepository labTestRepository, IMapper mapper)
        {
            _labTestRepository = labTestRepository;
            _mapper = mapper;
        }

        public async Task<LabTestDto?> GetLabTestByIdAsync(int labTestId)
        {
            var test = await _labTestRepository.GetByIdAsync(labTestId);
            return test == null ? null : _mapper.Map<LabTestDto>(test);
        }

        public async Task<IEnumerable<LabTestDto>> GetLabTestsByRecordAsync(int recordId)
        {
            var tests = await _labTestRepository.GetByRecordIdAsync(recordId);
            return _mapper.Map<IEnumerable<LabTestDto>>(tests);
        }

        public async Task<LabTestDto> AddLabTestAsync(CreateLabTestDto dto)
        {
            var test = _mapper.Map<LabTest>(dto);
            await _labTestRepository.AddAsync(test);
            return _mapper.Map<LabTestDto>(test);
        }

        public async Task<LabTestDto?> UpdateLabTestAsync(int id, UpdateLabTestDto dto)
        {
            var existing = await _labTestRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing);
            await _labTestRepository.UpdateAsync(existing);

            return _mapper.Map<LabTestDto>(existing);
        }
    }
}
