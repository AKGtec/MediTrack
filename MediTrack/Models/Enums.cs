namespace MediTrack.Models
{
    public class Enums
    {
        public enum Role { Patient, Doctor, Admin }
        public enum Gender { M, F, Other }
        public enum AppointmentStatus { Scheduled, Completed, Cancelled, NoShow }
        public enum AvailabilityStatus { Available, Busy, OnLeave }
        public enum InvoiceStatus { Paid, Pending, Cancelled }
        public enum PaymentMethod { CreditCard, PayPal, Cash, Insurance }
        public enum NotificationType { AppointmentReminder, Payment, General }
    }
}
