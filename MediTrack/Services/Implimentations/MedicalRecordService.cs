using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IMapper _mapper;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IMapper mapper)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _mapper = mapper;
        }

        public async Task<MedicalRecordDto?> GetRecordByIdAsync(int recordId)
        {
            var record = await _medicalRecordRepository.GetByIdAsync(recordId);
            return record == null ? null : _mapper.Map<MedicalRecordDto>(record);
        }

        public async Task<IEnumerable<MedicalRecordDto>> GetRecordsByPatientAsync(int patientId)
        {
            var records = await _medicalRecordRepository.GetByPatientIdAsync(patientId);
            return _mapper.Map<IEnumerable<MedicalRecordDto>>(records);
        }

        public async Task<MedicalRecordDto> CreateRecordAsync(CreateMedicalRecordDto dto)
        {
            var record = _mapper.Map<MedicalRecord>(dto);
            record.CreatedAt = DateTime.UtcNow;
            await _medicalRecordRepository.AddAsync(record);
            return _mapper.Map<MedicalRecordDto>(record);
        }

        public async Task<MedicalRecordDto?> UpdateRecordAsync(int id, UpdateMedicalRecordDto dto)
        {
            var existing = await _medicalRecordRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing);
            await _medicalRecordRepository.UpdateAsync(existing);

            return _mapper.Map<MedicalRecordDto>(existing);
        }
    }
}
