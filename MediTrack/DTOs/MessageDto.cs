using System;

namespace MediTrack.DTOs
{
    // DTO for returning message details
    public class MessageDto
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; } = string.Empty; // optional
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; } = string.Empty; // optional
        public string MessageText { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }

    // DTO for sending a new message
    public class CreateMessageDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string MessageText { get; set; } = string.Empty;
    }

    // DTO for updating message read status
    public class UpdateMessageStatusDto
    {
        public bool IsRead { get; set; }
    }
}
