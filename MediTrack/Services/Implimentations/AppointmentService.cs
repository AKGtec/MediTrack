using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;
using static MediTrack.Models.Enums;

namespace MediTrack.Services.Implimentations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int appointmentId)
        {
            return await _appointmentRepository.GetByIdAsync(appointmentId);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorAsync(int doctorId)
        {
            return await _appointmentRepository.GetByDoctorIdAsync(doctorId);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(int patientId)
        {
            return await _appointmentRepository.GetByPatientIdAsync(patientId);
        }

        public async Task<Appointment> ScheduleAppointmentAsync(Appointment appointment)
        {
            appointment.Status = AppointmentStatus.Scheduled;
            appointment.CreatedAt = DateTime.UtcNow;

            await _appointmentRepository.AddAsync(appointment);
            return appointment;
        }

        public async Task<Appointment> UpdateAppointmentStatusAsync(int appointmentId, string status)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found");

            // Parse string to enum with validation
            if (!Enum.TryParse<AppointmentStatus>(status, true, out var appointmentStatus))
            {
                throw new ArgumentException($"Invalid appointment status: {status}");
            }

            appointment.Status = appointmentStatus;
            appointment.UpdatedAt = DateTime.UtcNow;
            await _appointmentRepository.UpdateAsync(appointment);
            return appointment;
        }

        public async Task<bool> CancelAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            if (appointment == null) return false;

            appointment.Status = AppointmentStatus.Cancelled;
            appointment.UpdatedAt = DateTime.UtcNow;
            await _appointmentRepository.UpdateAsync(appointment);
            return true;
        }
    }
}
