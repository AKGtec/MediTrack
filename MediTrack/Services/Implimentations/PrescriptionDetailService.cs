using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class PrescriptionDetailService : IPrescriptionDetailService
    {
        private readonly IPrescriptionDetailRepository _prescriptionDetailRepository;
        private readonly IMapper _mapper;

        public PrescriptionDetailService(IPrescriptionDetailRepository prescriptionDetailRepository, IMapper mapper)
        {
            _prescriptionDetailRepository = prescriptionDetailRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrescriptionDetailDto>> GetDetailsByPrescriptionAsync(int prescriptionId)
        {
            var details = await _prescriptionDetailRepository.GetByPrescriptionIdAsync(prescriptionId);
            return _mapper.Map<IEnumerable<PrescriptionDetailDto>>(details);
        }

        public async Task<PrescriptionDetailDto> AddDetailAsync(CreatePrescriptionDetailDto dto)
        {
            var detail = _mapper.Map<PrescriptionDetail>(dto);
            await _prescriptionDetailRepository.AddAsync(detail);
            return _mapper.Map<PrescriptionDetailDto>(detail);
        }

        public async Task<PrescriptionDetailDto?> UpdateDetailAsync(int id, UpdatePrescriptionDetailDto dto)
        {
            var existing = await _prescriptionDetailRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing);
            await _prescriptionDetailRepository.UpdateAsync(existing);

            return _mapper.Map<PrescriptionDetailDto>(existing);
        }

        public async Task<bool> DeleteDetailAsync(int detailId)
        {
            await _prescriptionDetailRepository.DeleteAsync(detailId);
            return true;
        }
    }
}
