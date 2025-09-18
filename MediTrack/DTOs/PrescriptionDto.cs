namespace MediTrack.DTOs
{
    // Output DTO
    public class PrescriptionDto
    {
        public int PrescriptionId { get; set; }
        public int RecordId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime PrescribedDate { get; set; }

        // Only IDs for details (to avoid circular serialization)
        public IEnumerable<int> PrescriptionDetailIds { get; set; }
    }

    // Input DTO for creation
    public class CreatePrescriptionDto
    {
        public int RecordId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime? PrescribedDate { get; set; } // allow override if needed
    }
}
