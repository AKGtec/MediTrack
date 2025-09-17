using MediTrack.Data;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Repositories.Implementaions
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly MTDbContext _context;

        public InvoiceRepository(MTDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice?> GetByIdAsync(int invoiceId)
        {
            return await _context.Invoices
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .Include(i => i.Appointment)
                .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId);
        }

        public async Task<IEnumerable<Invoice>> GetByPatientIdAsync(int patientId)
        {
            return await _context.Invoices
                .Where(i => i.PatientId == patientId)
                .Include(i => i.Doctor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetByDoctorIdAsync(int doctorId)
        {
            return await _context.Invoices
                .Where(i => i.DoctorId == doctorId)
                .Include(i => i.Patient)
                .ToListAsync();
        }

        public async Task AddAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int invoiceId)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceId);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
