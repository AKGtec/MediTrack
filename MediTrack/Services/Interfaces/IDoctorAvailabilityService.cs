using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IDoctorAvailabilityService
    {
        Task<IEnumerable<DoctorAvailabilityDto>> GetAvailabilityByDoctorAsync(int doctorId);
        Task<DoctorAvailabilityDto> AddAvailabilityAsync(CreateDoctorAvailabilityDto dto);
        Task<DoctorAvailabilityDto?> UpdateAvailabilityAsync(int id, UpdateDoctorAvailabilityDto dto);
        Task<bool> DeleteAvailabilityAsync(int availabilityId);
    }
}
