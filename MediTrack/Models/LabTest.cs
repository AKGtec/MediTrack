using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediTrack.Models
{
    public class LabTest
    {
        [Key]
        public int LabTestId { get; set; }

        [Required, ForeignKey(nameof(MedicalRecord))]
        public int RecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        [Required, MaxLength(200)]
        public string TestName { get; set; }

        public string Results { get; set; }

        [MaxLength(1000)]
        public string FileUrl { get; set; } // path to uploaded report

        public DateTime TestDate { get; set; } = DateTime.UtcNow;
    }
}
