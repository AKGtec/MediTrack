using System.ComponentModel.DataAnnotations;
using static MediTrack.Models.Enums;

namespace MediTrack.DTOs
{
    // DTO for returning appointment details
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    // DTO for creating a new appointment
    public class CreateAppointmentDto
    {
        [Required(ErrorMessage = "Patient ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Patient ID must be a positive number")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Doctor ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Doctor ID must be a positive number")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        public DateTime AppointmentDate { get; set; }
    }

    // DTO for updating appointment status
    public class UpdateAppointmentStatusDto
    {
        [Required(ErrorMessage = "Status is required")]
        [EnumDataType(typeof(AppointmentStatus), ErrorMessage = "Invalid appointment status")]
        public AppointmentStatus Status { get; set; }
    }
}