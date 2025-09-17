using MediTrack.Models;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordsController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        // GET: api/MedicalRecords/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MedicalRecord>> GetRecordById(int id)
        {
            var record = await _medicalRecordService.GetRecordByIdAsync(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/MedicalRecords/Patient/5
        [HttpGet("Patient/{patientId:int}")]
        public async Task<ActionResult<IEnumerable<MedicalRecord>>> GetRecordsByPatient(int patientId)
        {
            var records = await _medicalRecordService.GetRecordsByPatientAsync(patientId);
            return Ok(records);
        }

        // POST: api/MedicalRecords
        [HttpPost]
        public async Task<ActionResult<MedicalRecord>> CreateRecord([FromBody] MedicalRecord record)
        {
            if (record == null)
                return BadRequest("Medical record cannot be null.");

            var createdRecord = await _medicalRecordService.CreateRecordAsync(record);
            return CreatedAtAction(nameof(GetRecordById), new { id = createdRecord.RecordId }, createdRecord);
        }

        // PUT: api/MedicalRecords/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<MedicalRecord>> UpdateRecord(int id, [FromBody] MedicalRecord record)
        {
            if (record == null || record.RecordId != id)
                return BadRequest("Invalid medical record data.");

            var updatedRecord = await _medicalRecordService.UpdateRecordAsync(record);
            return Ok(updatedRecord);
        }
    }
}
