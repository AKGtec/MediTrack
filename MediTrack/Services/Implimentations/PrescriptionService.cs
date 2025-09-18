using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMapper _mapper;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper)
        {
            _prescriptionRepository = prescriptionRepository;
            _mapper = mapper;
        }

        public async Task<PrescriptionDto?> GetPrescriptionByIdAsync(int prescriptionId)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(prescriptionId);
            if (prescription == null) return null;
            return _mapper.Map<PrescriptionDto>(prescription);
        }

        public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByPatientAsync(int patientId)
        {
            var prescriptions = await _prescriptionRepository.GetByPatientIdAsync(patientId);
            return _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
        }

        public async Task<PrescriptionDto> CreatePrescriptionAsync(CreatePrescriptionDto dto)
        {
            var prescription = _mapper.Map<Prescription>(dto);
            prescription.PrescribedDate = dto.PrescribedDate ?? DateTime.UtcNow;

            await _prescriptionRepository.AddAsync(prescription);
            return _mapper.Map<PrescriptionDto>(prescription);
        }
    }
}
