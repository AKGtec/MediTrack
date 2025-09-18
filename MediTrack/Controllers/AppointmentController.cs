using Microsoft.AspNetCore.Mvc;
using MediTrack.DTOs;
using MediTrack.Services.Interfaces;

namespace MediTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// Get appointment by ID
        /// </summary>
        /// <param name="id">Appointment ID</param>
        /// <returns>Appointment details</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            try
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
                if (appointment == null)
                {
                    return NotFound($"Appointment with ID {id} not found");
                }
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get appointments by doctor ID
        /// </summary>
        /// <param name="doctorId">Doctor ID</param>
        /// <returns>List of appointments for the doctor</returns>
        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByDoctor(int doctorId)
        {
            try
            {
                var appointments = await _appointmentService.GetAppointmentsByDoctorAsync(doctorId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get appointments by patient ID
        /// </summary>
        /// <param name="patientId">Patient ID</param>
        /// <returns>List of appointments for the patient</returns>
        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByPatient(int patientId)
        {
            try
            {
                var appointments = await _appointmentService.GetAppointmentsByPatientAsync(patientId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Schedule a new appointment
        /// </summary>
        /// <param name="createAppointmentDto">Appointment details</param>
        /// <returns>Created appointment</returns>
        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> ScheduleAppointment([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdAppointment = await _appointmentService.ScheduleAppointmentAsync(createAppointmentDto);
                return CreatedAtAction(
                    nameof(GetAppointment),
                    new { id = createdAppointment.AppointmentId },
                    createdAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Update appointment status
        /// </summary>
        /// <param name="id">Appointment ID</param>
        /// <param name="updateStatusDto">New status</param>
        /// <returns>Updated appointment</returns>
        [HttpPut("{id}/status")]
        public async Task<ActionResult<AppointmentDto>> UpdateAppointmentStatus(int id, [FromBody] UpdateAppointmentStatusDto updateStatusDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedAppointment = await _appointmentService.UpdateAppointmentStatusAsync(id, updateStatusDto);
                return Ok(updatedAppointment);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Cancel an appointment
        /// </summary>
        /// <param name="id">Appointment ID</param>
        /// <returns>Success status</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> CancelAppointment(int id)
        {
            try
            {
                var result = await _appointmentService.CancelAppointmentAsync(id);
                if (!result)
                {
                    return NotFound($"Appointment with ID {id} not found");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Alternative endpoint to cancel appointment using PATCH
        /// </summary>
        /// <param name="id">Appointment ID</param>
        /// <returns>Success status</returns>
        [HttpPatch("{id}/cancel")]
        public async Task<ActionResult> CancelAppointmentPatch(int id)
        {
            try
            {
                var result = await _appointmentService.CancelAppointmentAsync(id);
                if (!result)
                {
                    return NotFound($"Appointment with ID {id} not found");
                }
                return Ok(new { message = "Appointment cancelled successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}