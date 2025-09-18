using MediTrack.DTOs;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LabTestsController : ControllerBase
    {
        private readonly ILabTestService _labTestService;

        public LabTestsController(ILabTestService labTestService)
        {
            _labTestService = labTestService;
        }

        // GET: api/LabTests/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LabTestDto>> GetLabTestById(int id)
        {
            var test = await _labTestService.GetLabTestByIdAsync(id);
            if (test == null)
                return NotFound();

            return Ok(test);
        }

        // GET: api/LabTests/Record/5
        [HttpGet("Record/{recordId:int}")]
        public async Task<ActionResult<IEnumerable<LabTestDto>>> GetLabTestsByRecord(int recordId)
        {
            var tests = await _labTestService.GetLabTestsByRecordAsync(recordId);
            return Ok(tests);
        }

        // POST: api/LabTests
        [HttpPost]
        public async Task<ActionResult<LabTestDto>> AddLabTest([FromBody] CreateLabTestDto dto)
        {
            if (dto == null)
                return BadRequest("Lab test data cannot be null.");

            var createdTest = await _labTestService.AddLabTestAsync(dto);
            return CreatedAtAction(nameof(GetLabTestById), new { id = createdTest.LabTestId }, createdTest);
        }

        // PUT: api/LabTests/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<LabTestDto>> UpdateLabTest(int id, [FromBody] UpdateLabTestDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid lab test data.");

            var updatedTest = await _labTestService.UpdateLabTestAsync(id, dto);
            if (updatedTest == null)
                return NotFound();

            return Ok(updatedTest);
        }
    }
}
