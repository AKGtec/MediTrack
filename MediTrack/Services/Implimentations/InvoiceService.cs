using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(int invoiceId)
        {
            return await _invoiceRepository.GetByIdAsync(invoiceId);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByPatientAsync(int patientId)
        {
            return await _invoiceRepository.GetByPatientIdAsync(patientId);
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            await _invoiceRepository.AddAsync(invoice);
            return invoice;
        }

        public async Task<Invoice> UpdateInvoiceStatusAsync(int invoiceId, string status)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
                throw new KeyNotFoundException("Invoice not found.");

            invoice.Status = status;
            await _invoiceRepository.UpdateAsync(invoice);
            return invoice;
        }
    }
}
