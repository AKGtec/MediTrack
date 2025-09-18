using MediTrack.Data;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Repositories.Implementaions
{
    public class PrescriptionDetailRepository : IPrescriptionDetailRepository
    {
        private readonly MTDbContext _context;

        public PrescriptionDetailRepository(MTDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PrescriptionDetail>> GetByPrescriptionIdAsync(int prescriptionId)
        {
            return await _context.PrescriptionDetails
                .Where(d => d.PrescriptionId == prescriptionId)
                .ToListAsync();
        }

        public async Task AddAsync(PrescriptionDetail detail)
        {
            await _context.PrescriptionDetails.AddAsync(detail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PrescriptionDetail detail)
        {
            _context.PrescriptionDetails.Update(detail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int detailId)
        {
            var detail = await _context.PrescriptionDetails.FindAsync(detailId);
            if (detail != null)
            {
                _context.PrescriptionDetails.Remove(detail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PrescriptionDetail?> GetByIdAsync(int id)
        {
            return await _context.PrescriptionDetails.FindAsync(id);
        }
    }
   
}
