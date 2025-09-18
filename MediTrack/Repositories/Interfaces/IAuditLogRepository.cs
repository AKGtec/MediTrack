using MediTrack.Models;

namespace MediTrack.Repositories.Interfaces
{
    public interface IAuditLogRepository
    {
        // Your existing methods
        Task<AuditLog?> GetByIdAsync(int logId);
        Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId);
        Task AddAsync(AuditLog log);

        // Additional methods for enhanced functionality
        Task<IEnumerable<AuditLog>> GetAllAsync();
        Task<IEnumerable<AuditLog>> GetByActionAsync(string action);
        Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<AuditLog>> GetByIpAddressAsync(string ipAddress);
        Task<IEnumerable<AuditLog>> GetRecentLogsAsync(int count = 50);
    }
}