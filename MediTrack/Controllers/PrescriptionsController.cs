using MediTrack.Models;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        // GET: api/Prescriptions/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Prescription>> GetPrescriptionById(int id)
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
            if (prescription == null)
                return NotFound();

            return Ok(prescription);
        }

        // GET: api/Prescriptions/Patient/5
        [HttpGet("Patient/{patientId:int}")]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptionsByPatient(int patientId)
        {
            var prescriptions = await _prescriptionService.GetPrescriptionsByPatientAsync(patientId);
            return Ok(prescriptions);
        }

        // POST: api/Prescriptions
        [HttpPost]
        public async Task<ActionResult<Prescription>> CreatePrescription([FromBody] Prescription prescription)
        {
            if (prescription == null)
                return BadRequest("Prescription cannot be null.");

            var createdPrescription = await _prescriptionService.CreatePrescriptionAsync(prescription);
            return CreatedAtAction(nameof(GetPrescriptionById), new { id = createdPrescription.PrescriptionId }, createdPrescription);
        }
    }
}
