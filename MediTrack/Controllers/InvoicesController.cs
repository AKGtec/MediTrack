using MediTrack.DTOs;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/Invoices/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<InvoiceDto>> GetInvoiceById(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }

        // GET: api/Invoices/Patient/5
        [HttpGet("Patient/{patientId:int}")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetInvoicesByPatient(int patientId)
        {
            var invoices = await _invoiceService.GetInvoicesByPatientAsync(patientId);
            return Ok(invoices);
        }

        // POST: api/Invoices
        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> CreateInvoice([FromBody] CreateInvoiceDto dto)
        {
            if (dto == null)
                return BadRequest("Invoice cannot be null.");

            var createdInvoice = await _invoiceService.CreateInvoiceAsync(dto);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = createdInvoice.InvoiceId }, createdInvoice);
        }

        // PUT: api/Invoices/5/Status
        [HttpPut("{id:int}/Status")]
        public async Task<ActionResult<InvoiceDto>> UpdateInvoiceStatus(int id, [FromBody] UpdateInvoiceStatusDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid status data.");

            var updatedInvoice = await _invoiceService.UpdateInvoiceStatusAsync(id, dto);
            if (updatedInvoice == null)
                return NotFound();

            return Ok(updatedInvoice);
        }
    }
}
