using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityRepository _availabilityRepository;
        private readonly IMapper _mapper;

        public DoctorAvailabilityService(IDoctorAvailabilityRepository availabilityRepository, IMapper mapper)
        {
            _availabilityRepository = availabilityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorAvailabilityDto>> GetAvailabilityByDoctorAsync(int doctorId)
        {
            var availabilities = await _availabilityRepository.GetByDoctorIdAsync(doctorId);
            return _mapper.Map<IEnumerable<DoctorAvailabilityDto>>(availabilities);
        }

        public async Task<DoctorAvailabilityDto> AddAvailabilityAsync(CreateDoctorAvailabilityDto dto)
        {
            var availability = _mapper.Map<DoctorAvailability>(dto);
            await _availabilityRepository.AddAsync(availability);
            return _mapper.Map<DoctorAvailabilityDto>(availability);
        }

        public async Task<DoctorAvailabilityDto?> UpdateAvailabilityAsync(int id, UpdateDoctorAvailabilityDto dto)
        {
            var existing = await _availabilityRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing);
            await _availabilityRepository.UpdateAsync(existing);
            return _mapper.Map<DoctorAvailabilityDto>(existing);
        }

        public async Task<bool> DeleteAvailabilityAsync(int availabilityId)
        {
            await _availabilityRepository.DeleteAsync(availabilityId);
            return true;
        }
    }
}
