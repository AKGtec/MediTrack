using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediTrack.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required, ForeignKey(nameof(Sender))]
        public int SenderId { get; set; }
        public User Sender { get; set; }

        [Required, ForeignKey(nameof(Receiver))]
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }

        public string MessageText { get; set; }

        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;
    }
}
