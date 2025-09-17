using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static MediTrack.Models.Enums;

namespace MediTrack.Models
{
    [Table("Doctors")]
    public class Doctor : User
    {
        [Key] // will be the same as UserId
        [ForeignKey(nameof(User))]
        public new int UserId { get; set; }

        public string Specialization { get; set; }

        [MaxLength(100)]
        public string LicenseNumber { get; set; }

        public int? ExperienceYears { get; set; }

        public string ClinicName { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ConsultationFee { get; set; }

        public AvailabilityStatus AvailabilityStatus { get; set; } = AvailabilityStatus.Available;

        // Navigation
        public virtual ICollection<DoctorAvailability> Availabilities { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
