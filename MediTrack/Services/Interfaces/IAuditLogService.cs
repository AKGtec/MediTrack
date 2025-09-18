using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<AuditLogDto?> GetLogByIdAsync(int logId);
        Task<IEnumerable<AuditLogDto>> GetLogsByUserAsync(int userId);
        Task<IEnumerable<AuditLogDto>> GetAllLogsAsync();
        Task<AuditLogDto> AddLogAsync(CreateAuditLogDto createAuditLogDto);
        Task<IEnumerable<AuditLogDto>> GetLogsByActionAsync(string action);
        Task<IEnumerable<AuditLogDto>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}