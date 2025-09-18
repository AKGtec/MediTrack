using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentDto?> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            return payment == null ? null : _mapper.Map<PaymentDto>(payment);
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByInvoiceAsync(int invoiceId)
        {
            var payments = await _paymentRepository.GetByInvoiceIdAsync(invoiceId);
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto dto)
        {
            var payment = _mapper.Map<Payment>(dto);
            await _paymentRepository.AddAsync(payment);
            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<PaymentDto?> UpdatePaymentAsync(int id, UpdatePaymentDto dto)
        {
            var existing = await _paymentRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing);
            await _paymentRepository.UpdateAsync(existing);

            return _mapper.Map<PaymentDto>(existing);
        }

        public async Task<bool> DeletePaymentAsync(int paymentId)
        {
            await _paymentRepository.DeleteAsync(paymentId);
            return true;
        }
    }
}
