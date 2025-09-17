using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogService(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<AuditLog?> GetLogByIdAsync(int logId)
        {
            return await _auditLogRepository.GetByIdAsync(logId);
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByUserAsync(int userId)
        {
            return await _auditLogRepository.GetByUserIdAsync(userId);
        }

        public async Task AddLogAsync(AuditLog log)
        {
            await _auditLogRepository.AddAsync(log);
        }
    }
}
