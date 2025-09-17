using MediTrack.Models;

namespace MediTrack.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByIdAsync(int paymentId);
        Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(int paymentId);
    }
}
