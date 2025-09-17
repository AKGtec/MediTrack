using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediTrack.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        [Required, ForeignKey(nameof(MedicalRecord))]
        public int RecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        [Required, ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required, ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public DateTime PrescribedDate { get; set; } = DateTime.UtcNow;

        public virtual ICollection<PrescriptionDetail> Details { get; set; }
    }
}
