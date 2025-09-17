using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityRepository _availabilityRepository;

        public DoctorAvailabilityService(IDoctorAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<IEnumerable<DoctorAvailability>> GetAvailabilityByDoctorAsync(int doctorId)
        {
            return await _availabilityRepository.GetByDoctorIdAsync(doctorId);
        }

        public async Task<DoctorAvailability> AddAvailabilityAsync(DoctorAvailability availability)
        {
            await _availabilityRepository.AddAsync(availability);
            return availability;
        }

        public async Task<DoctorAvailability> UpdateAvailabilityAsync(DoctorAvailability availability)
        {
            await _availabilityRepository.UpdateAsync(availability);
            return availability;
        }

        public async Task<bool> DeleteAvailabilityAsync(int availabilityId)
        {
            await _availabilityRepository.DeleteAsync(availabilityId);
            return true;
        }
    }
}
