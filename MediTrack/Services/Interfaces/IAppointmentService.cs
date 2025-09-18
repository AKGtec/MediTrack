using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDto?> GetAppointmentByIdAsync(int appointmentId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorAsync(int doctorId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientAsync(int patientId);
        Task<AppointmentDto> ScheduleAppointmentAsync(CreateAppointmentDto createAppointmentDto);
        Task<AppointmentDto> UpdateAppointmentStatusAsync(int appointmentId, UpdateAppointmentStatusDto updateStatusDto);
        Task<bool> CancelAppointmentAsync(int appointmentId);
    }
}