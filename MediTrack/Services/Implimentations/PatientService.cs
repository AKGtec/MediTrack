using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }

        public async Task<PatientDto?> GetPatientByIdAsync(int patientId)
        {
            var patient = await _patientRepository.GetByIdAsync(patientId);
            return patient == null ? null : _mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto> CreatePatientAsync(CreatePatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);

            // ⚡ Example: hash password before saving
            // patient.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _patientRepository.AddAsync(patient);
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto?> UpdatePatientAsync(int id, UpdatePatientDto dto)
        {
            var existing = await _patientRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing);
            await _patientRepository.UpdateAsync(existing);

            return _mapper.Map<PatientDto>(existing);
        }

        public async Task<bool> DeletePatientAsync(int patientId)
        {
            await _patientRepository.DeleteAsync(patientId);
            return true;
        }
    }
}
