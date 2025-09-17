using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static MediTrack.Models.Enums;

namespace MediTrack.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required, ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        public string Message { get; set; }

        public NotificationType Type { get; set; } = NotificationType.General;

        public bool IsRead { get; set; } = false;

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
