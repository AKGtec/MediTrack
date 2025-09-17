using MediTrack.Models;
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
        public async Task<ActionResult<IEnumerable<DoctorAvailability>>> GetAvailabilityByDoctor(int doctorId)
        {
            var availability = await _availabilityService.GetAvailabilityByDoctorAsync(doctorId);
            return Ok(availability);
        }

        // POST: api/DoctorAvailability
        [HttpPost]
        public async Task<ActionResult<DoctorAvailability>> AddAvailability([FromBody] DoctorAvailability availability)
        {
            if (availability == null)
                return BadRequest("Availability cannot be null.");

            var created = await _availabilityService.AddAvailabilityAsync(availability);
            return CreatedAtAction(nameof(GetAvailabilityByDoctor), new { doctorId = created.DoctorId }, created);
        }

        // PUT: api/DoctorAvailability/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<DoctorAvailability>> UpdateAvailability(int id, [FromBody] DoctorAvailability availability)
        {
            if (availability == null || availability.AvailabilityId != id)
                return BadRequest("Invalid availability data.");

            var updated = await _availabilityService.UpdateAvailabilityAsync(availability);
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
