using MediTrack.Models;

namespace MediTrack.Repositories.Interfaces
{
    public interface IAuditLogRepository
    {
        Task<AuditLog?> GetByIdAsync(int logId);
        Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId);
        Task AddAsync(AuditLog log);
    }
}
