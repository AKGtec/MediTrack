using System;
using System.Collections.Generic;
using static MediTrack.Models.Enums;

namespace MediTrack.DTOs
{
    // DTO for returning doctor details
    public class DoctorDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public int? ExperienceYears { get; set; }
        public string ClinicName { get; set; } = string.Empty;
        public decimal? ConsultationFee { get; set; }
        public AvailabilityStatus AvailabilityStatus { get; set; }
    }

    // DTO for creating a doctor
    public class CreateDoctorDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // plaintext input, hash in service
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string Address { get; set; } = string.Empty;

        // Doctor-specific
        public string Specialization { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public int? ExperienceYears { get; set; }
        public string ClinicName { get; set; } = string.Empty;
        public decimal? ConsultationFee { get; set; }
    }

    // DTO for updating doctor info
    public class UpdateDoctorDto
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // Doctor-specific
        public string Specialization { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public int? ExperienceYears { get; set; }
        public string ClinicName { get; set; } = string.Empty;
        public decimal? ConsultationFee { get; set; }
        public AvailabilityStatus AvailabilityStatus { get; set; }
    }
}
