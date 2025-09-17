using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediTrack.Models
{
    public class MedicalRecord
    {
        [Key]
        public int RecordId { get; set; }

        [Required, ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required, ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey(nameof(Appointment))]
        public int? AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public string Diagnosis { get; set; }

        public string TreatmentPlan { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<LabTest> LabTests { get; set; }
    }
}
