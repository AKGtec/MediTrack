using System;

namespace MediTrack.DTOs
{
    // DTO for returning doctor availability
    public class DoctorAvailabilityDto
    {
        public int AvailabilityId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty; // optional
        public string DayOfWeek { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

    // DTO for creating a new availability
    public class CreateDoctorAvailabilityDto
    {
        public int DoctorId { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

    // DTO for updating availability
    public class UpdateDoctorAvailabilityDto
    {
        public string DayOfWeek { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
