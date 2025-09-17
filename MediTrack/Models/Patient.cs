using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediTrack.Models
{
    [Table("Patients")]
    public class Patient : User
    {
        [Key]
        [ForeignKey(nameof(User))]
        public new int UserId { get; set; }

        [MaxLength(5)]
        public string BloodType { get; set; }

        public string Allergies { get; set; }

        public string ChronicConditions { get; set; }

        [MaxLength(200)]
        public string EmergencyContactName { get; set; }

        [MaxLength(20)]
        public string EmergencyContactPhone { get; set; }

        // Navigation
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
