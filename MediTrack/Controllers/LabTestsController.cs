using MediTrack.Models;
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
        public async Task<ActionResult<LabTest>> GetLabTestById(int id)
        {
            var test = await _labTestService.GetLabTestByIdAsync(id);
            if (test == null)
                return NotFound();

            return Ok(test);
        }

        // GET: api/LabTests/Record/5
        [HttpGet("Record/{recordId:int}")]
        public async Task<ActionResult<IEnumerable<LabTest>>> GetLabTestsByRecord(int recordId)
        {
            var tests = await _labTestService.GetLabTestsByRecordAsync(recordId);
            return Ok(tests);
        }

        // POST: api/LabTests
        [HttpPost]
        public async Task<ActionResult<LabTest>> AddLabTest([FromBody] LabTest test)
        {
            if (test == null)
                return BadRequest("Lab test data cannot be null.");

            var createdTest = await _labTestService.AddLabTestAsync(test);
            return CreatedAtAction(nameof(GetLabTestById), new { id = createdTest.LabTestId }, createdTest);
        }

        // PUT: api/LabTests/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<LabTest>> UpdateLabTest(int id, [FromBody] LabTest test)
        {
            if (test == null || test.LabTestId != id)
                return BadRequest("Invalid lab test data.");

            var updatedTest = await _labTestService.UpdateLabTestAsync(test);
            return Ok(updatedTest);
        }
    }
}
