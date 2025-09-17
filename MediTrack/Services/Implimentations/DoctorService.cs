using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int doctorId)
        {
            return await _doctorRepository.GetByIdAsync(doctorId);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<Doctor> CreateDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.AddAsync(doctor);
            return doctor;
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.UpdateAsync(doctor);
            return doctor;
        }

        public async Task<bool> DeleteDoctorAsync(int doctorId)
        {
            await _doctorRepository.DeleteAsync(doctorId);
            return true;
        }
    }
}
