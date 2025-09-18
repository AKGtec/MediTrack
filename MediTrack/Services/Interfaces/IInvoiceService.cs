using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceDto?> GetInvoiceByIdAsync(int invoiceId);
        Task<IEnumerable<InvoiceDto>> GetInvoicesByPatientAsync(int patientId);
        Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceDto dto);
        Task<InvoiceDto?> UpdateInvoiceStatusAsync(int invoiceId, UpdateInvoiceStatusDto dto);
    }
}
