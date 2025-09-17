using MediTrack.Models;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogsController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogsController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        // GET: api/AuditLogs/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AuditLog>> GetLogById(int id)
        {
            var log = await _auditLogService.GetLogByIdAsync(id);
            if (log == null)
                return NotFound();

            return Ok(log);
        }

        // GET: api/AuditLogs/User/{userId}
        [HttpGet("User/{userId:int}")]
        public async Task<ActionResult<IEnumerable<AuditLog>>> GetLogsByUser(int userId)
        {
            var logs = await _auditLogService.GetLogsByUserAsync(userId);
            return Ok(logs);
        }

        // POST: api/AuditLogs
        [HttpPost]
        public async Task<ActionResult> AddLog([FromBody] AuditLog log)
        {
            if (log == null)
                return BadRequest("Log cannot be null.");

            await _auditLogService.AddLogAsync(log);
            return CreatedAtAction(nameof(GetLogById), new { id = log.LogId }, log);
        }
    }
}
