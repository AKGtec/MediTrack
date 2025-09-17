using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface IDoctorAvailabilityService
    {
        Task<IEnumerable<DoctorAvailability>> GetAvailabilityByDoctorAsync(int doctorId);
        Task<DoctorAvailability> AddAvailabilityAsync(DoctorAvailability availability);
        Task<DoctorAvailability> UpdateAvailabilityAsync(DoctorAvailability availability);
        Task<bool> DeleteAvailabilityAsync(int availabilityId);
    }
}
