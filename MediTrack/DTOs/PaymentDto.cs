using System;
using static MediTrack.Models.Enums;

namespace MediTrack.DTOs
{
    // DTO for returning payment details
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
    }

    // DTO for creating a new payment
    public class CreatePaymentDto
    {
        public int InvoiceId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public decimal AmountPaid { get; set; }
    }

    // DTO for updating a payment
    public class UpdatePaymentDto
    {
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public decimal AmountPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
