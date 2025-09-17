using MediTrack.Models;

namespace MediTrack.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<Invoice?> GetByIdAsync(int invoiceId);
        Task<IEnumerable<Invoice>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<Invoice>> GetByDoctorIdAsync(int doctorId);
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(int invoiceId);
    }
}
