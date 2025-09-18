using System;
using MediTrack.Models;
using static MediTrack.Models.Enums;

namespace MediTrack.DTOs
{
    // DTO for returning notification details
    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty; // optional
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime SentAt { get; set; }
    }

    // DTO for creating a new notification
    public class CreateNotificationDto
    {
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; } = NotificationType.General;
    }

    // DTO for updating notification status (mark as read)
    public class UpdateNotificationStatusDto
    {
        public bool IsRead { get; set; } = true;
    }
}
