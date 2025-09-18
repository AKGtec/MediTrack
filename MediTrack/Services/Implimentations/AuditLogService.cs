using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implementations
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;
        private readonly IMapper _mapper;

        public AuditLogService(IAuditLogRepository auditLogRepository, IMapper mapper)
        {
            _auditLogRepository = auditLogRepository;
            _mapper = mapper;
        }

        public async Task<AuditLogDto?> GetLogByIdAsync(int logId)
        {
            var log = await _auditLogRepository.GetByIdAsync(logId);
            return log == null ? null : _mapper.Map<AuditLogDto>(log);
        }

        public async Task<IEnumerable<AuditLogDto>> GetLogsByUserAsync(int userId)
        {
            var logs = await _auditLogRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<AuditLogDto>>(logs);
        }

        public async Task<IEnumerable<AuditLogDto>> GetAllLogsAsync()
        {
            var logs = await _auditLogRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuditLogDto>>(logs);
        }

        public async Task<AuditLogDto> AddLogAsync(CreateAuditLogDto createAuditLogDto)
        {
            var log = _mapper.Map<AuditLog>(createAuditLogDto);
            log.Timestamp = DateTime.UtcNow;

            await _auditLogRepository.AddAsync(log);
            return _mapper.Map<AuditLogDto>(log);
        }

        public async Task<IEnumerable<AuditLogDto>> GetLogsByActionAsync(string action)
        {
            var logs = await _auditLogRepository.GetByActionAsync(action);
            return _mapper.Map<IEnumerable<AuditLogDto>>(logs);
        }

        public async Task<IEnumerable<AuditLogDto>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var logs = await _auditLogRepository.GetByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<AuditLogDto>>(logs);
        }
    }
}