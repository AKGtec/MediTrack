using MediTrack.Models;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        // GET: api/Patients/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        // POST: api/Patients
        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient([FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest("Patient data cannot be null.");

            var createdPatient = await _patientService.CreatePatientAsync(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.UserId }, createdPatient);
        }

        // PUT: api/Patients/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Patient>> UpdatePatient(int id, [FromBody] Patient patient)
        {
            if (patient == null || patient.UserId != id)
                return BadRequest("Invalid patient data.");

            var updatedPatient = await _patientService.UpdatePatientAsync(patient);
            return Ok(updatedPatient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
