using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static MediTrack.Models.Enums;

namespace MediTrack.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required, ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [MaxLength(200)]
        public string TransactionId { get; set; } // unique if online

        [Column(TypeName = "decimal(12,2)")]
        public decimal AmountPaid { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    }
}
