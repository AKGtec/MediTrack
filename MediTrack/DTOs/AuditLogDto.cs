using System.ComponentModel.DataAnnotations;

namespace MediTrack.DTOs
{
    // DTO for returning audit log details
    public class AuditLogDto
    {
        public int LogId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string IpAddress { get; set; } = string.Empty;
    }

    // DTO for creating a new audit log
    public class CreateAuditLogDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "User ID must be a positive number")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Action is required")]
        [StringLength(200, ErrorMessage = "Action cannot exceed 200 characters")]
        public string Action { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "IP Address cannot exceed 100 characters")]
        public string IpAddress { get; set; } = string.Empty;
    }

    // DTO for filtering audit logs
    public class AuditLogFilterDto
    {
        public int? UserId { get; set; }
        public string? Action { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? IpAddress { get; set; }
    }
}