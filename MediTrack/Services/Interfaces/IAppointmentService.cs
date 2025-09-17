using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment?> GetAppointmentByIdAsync(int appointmentId);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorAsync(int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(int patientId);
        Task<Appointment> ScheduleAppointmentAsync(Appointment appointment);
        Task<Appointment> UpdateAppointmentStatusAsync(int appointmentId, string status);
        Task<bool> CancelAppointmentAsync(int appointmentId);
    }
}
