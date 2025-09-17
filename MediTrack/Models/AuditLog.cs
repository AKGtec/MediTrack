using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediTrack.Models
{
    public class AuditLog
    {
        [Key]
        public int LogId { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public User User { get; set; }

        [MaxLength(200)]
        public string Action { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string IpAddress { get; set; }
    }
}
