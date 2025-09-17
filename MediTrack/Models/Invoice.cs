using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static MediTrack.Models.Enums;

namespace MediTrack.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required, ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [Required, ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required, ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Amount { get; set; }

        public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;

        public DateTime IssuedDate { get; set; } = DateTime.UtcNow;

        public DateTime? PaidDate { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
