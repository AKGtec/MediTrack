using System;

namespace MediTrack.DTOs
{
    // DTO for returning lab test details
    public class LabTestDto
    {
        public int LabTestId { get; set; }
        public int RecordId { get; set; }
        public string TestName { get; set; } = string.Empty;
        public string? Results { get; set; }
        public string? FileUrl { get; set; }
        public DateTime TestDate { get; set; }
    }

    // DTO for creating a new lab test
    public class CreateLabTestDto
    {
        public int RecordId { get; set; }
        public string TestName { get; set; } = string.Empty;
        public string? Results { get; set; }
        public string? FileUrl { get; set; }
    }

    // DTO for updating an existing lab test
    public class UpdateLabTestDto
    {
        public string? Results { get; set; }
        public string? FileUrl { get; set; }
        public DateTime? TestDate { get; set; }
    }
}
