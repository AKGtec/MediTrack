using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment?> GetPaymentByIdAsync(int paymentId)
        {
            return await _paymentRepository.GetByIdAsync(paymentId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByInvoiceAsync(int invoiceId)
        {
            return await _paymentRepository.GetByInvoiceIdAsync(invoiceId);
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            await _paymentRepository.AddAsync(payment);
            return payment;
        }

        public async Task<Payment> UpdatePaymentAsync(Payment payment)
        {
            await _paymentRepository.UpdateAsync(payment);
            return payment;
        }

        public async Task<bool> DeletePaymentAsync(int paymentId)
        {
            await _paymentRepository.DeleteAsync(paymentId);
            return true;
        }
    }
}
