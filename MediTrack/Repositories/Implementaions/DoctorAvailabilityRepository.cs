using MediTrack.Data;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Repositories.Implementaions
{
    public class DoctorAvailabilityRepository : IDoctorAvailabilityRepository
    {
        private readonly MTDbContext _context;

        public DoctorAvailabilityRepository(MTDbContext context)
        {
            _context = context;
        }

        public async Task<DoctorAvailability?> GetByIdAsync(int availabilityId)
        {
            return await _context.DoctorAvailabilities
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.AvailabilityId == availabilityId);
        }

        public async Task<IEnumerable<DoctorAvailability>> GetByDoctorIdAsync(int doctorId)
        {
            return await _context.DoctorAvailabilities
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task AddAsync(DoctorAvailability availability)
        {
            await _context.DoctorAvailabilities.AddAsync(availability);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DoctorAvailability availability)
        {
            _context.DoctorAvailabilities.Update(availability);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int availabilityId)
        {
            var availability = await _context.DoctorAvailabilities.FindAsync(availabilityId);
            if (availability != null)
            {
                _context.DoctorAvailabilities.Remove(availability);
                await _context.SaveChangesAsync();
            }
        }
    }
}
