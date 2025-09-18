namespace MediTrack.DTOs
{
    // DTO for returning details
    public class PrescriptionDetailDto
    {
        public int PrescriptionDetailId { get; set; }
        public int PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public string Instructions { get; set; }
    }

    // DTO for creating new detail
    public class CreatePrescriptionDetailDto
    {
        public int PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public string Instructions { get; set; }
    }

    // DTO for updating an existing detail
    public class UpdatePrescriptionDetailDto
    {
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public string Instructions { get; set; }
    }
}
