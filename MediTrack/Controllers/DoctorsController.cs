using MediTrack.Models;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        // GET: api/Doctors/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> CreateDoctor([FromBody] Doctor doctor)
        {
            if (doctor == null)
                return BadRequest("Doctor data is null.");

            var createdDoctor = await _doctorService.CreateDoctorAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = createdDoctor.UserId }, createdDoctor);
        }

        // PUT: api/Doctors/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Doctor>> UpdateDoctor(int id, [FromBody] Doctor doctor)
        {
            if (doctor == null || doctor.UserId != id)
                return BadRequest("Invalid doctor data.");

            var updatedDoctor = await _doctorService.UpdateDoctorAsync(doctor);
            return Ok(updatedDoctor);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var result = await _doctorService.DeleteDoctorAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
