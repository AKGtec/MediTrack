using MediTrack.DTOs;
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

        /// <summary>
        /// Get audit log by ID
        /// </summary>
        /// <param name="id">Log ID</param>
        /// <returns>Audit log details</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AuditLogDto>> GetLogById(int id)
        {
            try
            {
                var log = await _auditLogService.GetLogByIdAsync(id);
                if (log == null)
                {
                    return NotFound($"Audit log with ID {id} not found");
                }
                return Ok(log);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get audit logs by user ID
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>List of audit logs for the user</returns>
        [HttpGet("User/{userId:int}")]
        public async Task<ActionResult<IEnumerable<AuditLogDto>>> GetLogsByUser(int userId)
        {
            try
            {
                var logs = await _auditLogService.GetLogsByUserAsync(userId);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all audit logs
        /// </summary>
        /// <returns>List of all audit logs</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditLogDto>>> GetAllLogs()
        {
            try
            {
                var logs = await _auditLogService.GetAllLogsAsync();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Add a new audit log
        /// </summary>
        /// <param name="createAuditLogDto">Audit log details</param>
        /// <returns>Created audit log</returns>
        [HttpPost]
        public async Task<ActionResult<AuditLogDto>> AddLog([FromBody] CreateAuditLogDto createAuditLogDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdLog = await _auditLogService.AddLogAsync(createAuditLogDto);
                return CreatedAtAction(
                    nameof(GetLogById),
                    new { id = createdLog.LogId },
                    createdLog);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get audit logs by action type
        /// </summary>
        /// <param name="action">Action type</param>
        /// <returns>List of audit logs for the action</returns>
        [HttpGet("Action/{action}")]
        public async Task<ActionResult<IEnumerable<AuditLogDto>>> GetLogsByAction(string action)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(action))
                {
                    return BadRequest("Action parameter cannot be empty");
                }

                var logs = await _auditLogService.GetLogsByActionAsync(action);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get audit logs within a date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>List of audit logs within the date range</returns>
        [HttpGet("DateRange")]
        public async Task<ActionResult<IEnumerable<AuditLogDto>>> GetLogsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                if (startDate > endDate)
                {
                    return BadRequest("Start date cannot be greater than end date");
                }

                var logs = await _auditLogService.GetLogsByDateRangeAsync(startDate, endDate);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}