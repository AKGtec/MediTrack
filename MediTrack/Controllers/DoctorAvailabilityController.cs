using MediTrack.DTOs;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly IDoctorAvailabilityService _availabilityService;

        public DoctorAvailabilityController(IDoctorAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }

        // GET: api/DoctorAvailability/Doctor/5
        [HttpGet("Doctor/{doctorId:int}")]
        public async Task<ActionResult<IEnumerable<DoctorAvailabilityDto>>> GetAvailabilityByDoctor(int doctorId)
        {
            var availability = await _availabilityService.GetAvailabilityByDoctorAsync(doctorId);
            return Ok(availability);
        }

        // POST: api/DoctorAvailability
        [HttpPost]
        public async Task<ActionResult<DoctorAvailabilityDto>> AddAvailability([FromBody] CreateDoctorAvailabilityDto dto)
        {
            if (dto == null)
                return BadRequest("Availability cannot be null.");

            var created = await _availabilityService.AddAvailabilityAsync(dto);
            return CreatedAtAction(nameof(GetAvailabilityByDoctor), new { doctorId = created.DoctorId }, created);
        }

        // PUT: api/DoctorAvailability/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<DoctorAvailabilityDto>> UpdateAvailability(int id, [FromBody] UpdateDoctorAvailabilityDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid availability data.");

            var updated = await _availabilityService.UpdateAvailabilityAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/DoctorAvailability/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAvailability(int id)
        {
            var result = await _availabilityService.DeleteAvailabilityAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
