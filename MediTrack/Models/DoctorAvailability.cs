using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediTrack.Models
{
    public class DoctorAvailability
    {
        [Key]
        public int AvailabilityId { get; set; }

        [Required, ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required, MaxLength(10)]
        public string DayOfWeek { get; set; } // "Mon", "Tue"... or full name

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }
    }
}
