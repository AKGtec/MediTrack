using MediTrack.Data;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Repositories.Implementaions
{
    public class LabTestRepository : ILabTestRepository
    {
        private readonly MTDbContext _context;

        public LabTestRepository(MTDbContext context)
        {
            _context = context;
        }

        public async Task<LabTest?> GetByIdAsync(int labTestId)
        {
            return await _context.LabTests
                .Include(t => t.MedicalRecord)
                .FirstOrDefaultAsync(t => t.LabTestId == labTestId);
        }

        public async Task<IEnumerable<LabTest>> GetByRecordIdAsync(int recordId)
        {
            return await _context.LabTests
                .Where(t => t.RecordId == recordId)
                .ToListAsync();
        }

        public async Task AddAsync(LabTest test)
        {
            await _context.LabTests.AddAsync(test);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LabTest test)
        {
            _context.LabTests.Update(test);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int labTestId)
        {
            var test = await _context.LabTests.FindAsync(labTestId);
            if (test != null)
            {
                _context.LabTests.Remove(test);
                await _context.SaveChangesAsync();
            }
        }
    }
}
