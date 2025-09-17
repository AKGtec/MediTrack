using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediTrack.Models
{
    public class PrescriptionDetail
    {
        [Key]
        public int PrescriptionDetailId { get; set; }

        [Required, ForeignKey(nameof(Prescription))]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        [Required, MaxLength(200)]
        public string MedicineName { get; set; }

        [MaxLength(100)]
        public string Dosage { get; set; }

        [MaxLength(100)]
        public string Frequency { get; set; } // e.g., "2x/day"

        [MaxLength(100)]
        public string Duration { get; set; } // e.g., "7 days"

        public string Instructions { get; set; }
    }
}
