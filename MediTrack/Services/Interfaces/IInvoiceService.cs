using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice?> GetInvoiceByIdAsync(int invoiceId);
        Task<IEnumerable<Invoice>> GetInvoicesByPatientAsync(int patientId);
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);
        Task<Invoice> UpdateInvoiceStatusAsync(int invoiceId, string status);
    }
}
