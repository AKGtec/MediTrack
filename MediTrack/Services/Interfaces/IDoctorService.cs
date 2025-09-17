using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor?> GetDoctorByIdAsync(int doctorId);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> CreateDoctorAsync(Doctor doctor);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor);
        Task<bool> DeleteDoctorAsync(int doctorId);
    }
}
