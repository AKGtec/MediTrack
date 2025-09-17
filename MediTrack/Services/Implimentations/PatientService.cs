using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient?> GetPatientByIdAsync(int patientId)
        {
            return await _patientRepository.GetByIdAsync(patientId);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
            return patient;
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
            return patient;
        }

        public async Task<bool> DeletePatientAsync(int patientId)
        {
            await _patientRepository.DeleteAsync(patientId);
            return true;
        }
    }
}
