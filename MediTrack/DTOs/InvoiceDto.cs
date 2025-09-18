using System;
using System.Collections.Generic;
using static MediTrack.Models.Enums;

namespace MediTrack.DTOs
{
    // DTO for returning invoice details
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty; // optional
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty; // optional
        public decimal Amount { get; set; }
        public InvoiceStatus Status { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public IEnumerable<PaymentDto>? Payments { get; set; } // include payments if needed
    }

    // DTO for creating a new invoice
    public class CreateInvoiceDto
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public decimal Amount { get; set; }
    }

    // DTO for updating invoice status
    public class UpdateInvoiceStatusDto
    {
        public InvoiceStatus Status { get; set; }
        public DateTime? PaidDate { get; set; } // optional, set when marking as paid
    }

    // Simple DTO for payments included in InvoiceDto
 
}
