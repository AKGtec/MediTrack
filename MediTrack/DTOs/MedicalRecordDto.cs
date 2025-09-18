using System;
using System.Collections.Generic;

namespace MediTrack.DTOs
{
    // DTO for returning medical record details
    public class MedicalRecordDto
    {
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty; // optional
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty; // optional
        public int? AppointmentId { get; set; }
        public string? Diagnosis { get; set; }
        public string? TreatmentPlan { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<PrescriptionDto>? Prescriptions { get; set; }
        public IEnumerable<LabTestDto>? LabTests { get; set; }
    }

    // DTO for creating a new medical record
    public class CreateMedicalRecordDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int? AppointmentId { get; set; }
        public string? Diagnosis { get; set; }
        public string? TreatmentPlan { get; set; }
        public string? Notes { get; set; }
    }

    // DTO for updating an existing medical record
    public class UpdateMedicalRecordDto
    {
        public string? Diagnosis { get; set; }
        public string? TreatmentPlan { get; set; }
        public string? Notes { get; set; }
    }
}
