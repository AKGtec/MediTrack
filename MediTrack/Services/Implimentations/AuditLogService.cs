using MediTrack.Data;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Repositories.Implementations // Fixed typo: "Implementaions" -> "Implementations"
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly MTDbContext _context;

        public AuditLogRepository(MTDbContext context)
        {
            _context = context;
        }

        public async Task<AuditLog?> GetByIdAsync(int logId)
        {
            return await _context.AuditLogs
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.LogId == logId);
        }

        public async Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId)
        {
            return await _context.AuditLogs
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
        }

        public async Task AddAsync(AuditLog log)
        {
            await _context.AuditLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}