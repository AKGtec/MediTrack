using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<AuditLog?> GetLogByIdAsync(int logId);
        Task<IEnumerable<AuditLog>> GetLogsByUserAsync(int userId);
        Task AddLogAsync(AuditLog log);
    }
}
