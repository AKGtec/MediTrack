using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static MediTrack.Models.Enums;


namespace MediTrack.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required, ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required, ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; } // date + time combined

        // Alternatively, if you want separate date & time:
        // public DateTime AppointmentDate { get; set; }
        // public TimeSpan AppointmentTime { get; set; }

        [Required]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public virtual MedicalRecord MedicalRecord { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
