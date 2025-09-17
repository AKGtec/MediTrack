using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<Prescription?> GetPrescriptionByIdAsync(int prescriptionId)
        {
            return await _prescriptionRepository.GetByIdAsync(prescriptionId);
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByPatientAsync(int patientId)
        {
            return await _prescriptionRepository.GetByPatientIdAsync(patientId);
        }

        public async Task<Prescription> CreatePrescriptionAsync(Prescription prescription)
        {
            prescription.PrescribedDate = DateTime.UtcNow;
            await _prescriptionRepository.AddAsync(prescription);
            return prescription;
        }
    }
}
