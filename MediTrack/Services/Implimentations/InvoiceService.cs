using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<InvoiceDto?> GetInvoiceByIdAsync(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            return invoice == null ? null : _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<IEnumerable<InvoiceDto>> GetInvoicesByPatientAsync(int patientId)
        {
            var invoices = await _invoiceRepository.GetByPatientIdAsync(patientId);
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceDto dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);
            await _invoiceRepository.AddAsync(invoice);
            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<InvoiceDto?> UpdateInvoiceStatusAsync(int invoiceId, UpdateInvoiceStatusDto dto)
        {
            var existing = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing);
            await _invoiceRepository.UpdateAsync(existing);
            return _mapper.Map<InvoiceDto>(existing);
        }
    }
}
