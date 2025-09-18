using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentDto?> GetPaymentByIdAsync(int paymentId);
        Task<IEnumerable<PaymentDto>> GetPaymentsByInvoiceAsync(int invoiceId);
        Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto dto);
        Task<PaymentDto?> UpdatePaymentAsync(int id, UpdatePaymentDto dto);
        Task<bool> DeletePaymentAsync(int paymentId);
    }
}
