using MediTrack.DTOs;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionDetailsController : ControllerBase
    {
        private readonly IPrescriptionDetailService _prescriptionDetailService;

        public PrescriptionDetailsController(IPrescriptionDetailService prescriptionDetailService)
        {
            _prescriptionDetailService = prescriptionDetailService;
        }

        // GET: api/PrescriptionDetails/Prescription/5
        [HttpGet("Prescription/{prescriptionId:int}")]
        public async Task<ActionResult<IEnumerable<PrescriptionDetailDto>>> GetDetailsByPrescription(int prescriptionId)
        {
            var details = await _prescriptionDetailService.GetDetailsByPrescriptionAsync(prescriptionId);
            return Ok(details);
        }

        // POST: api/PrescriptionDetails
        [HttpPost]
        public async Task<ActionResult<PrescriptionDetailDto>> AddDetail([FromBody] CreatePrescriptionDetailDto dto)
        {
            if (dto == null)
                return BadRequest("Prescription detail cannot be null.");

            var createdDetail = await _prescriptionDetailService.AddDetailAsync(dto);
            return CreatedAtAction(nameof(GetDetailsByPrescription), new { prescriptionId = createdDetail.PrescriptionId }, createdDetail);
        }

        // PUT: api/PrescriptionDetails/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PrescriptionDetailDto>> UpdateDetail(int id, [FromBody] UpdatePrescriptionDetailDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid prescription detail data.");

            var updatedDetail = await _prescriptionDetailService.UpdateDetailAsync(id, dto);
            if (updatedDetail == null)
                return NotFound();

            return Ok(updatedDetail);
        }

        // DELETE: api/PrescriptionDetails/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteDetail(int id)
        {
            var result = await _prescriptionDetailService.DeleteDetailAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
