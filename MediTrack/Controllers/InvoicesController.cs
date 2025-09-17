using MediTrack.Models;
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
        public async Task<ActionResult<Invoice>> GetInvoiceById(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }

        // GET: api/Invoices/Patient/5
        [HttpGet("Patient/{patientId:int}")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoicesByPatient(int patientId)
        {
            var invoices = await _invoiceService.GetInvoicesByPatientAsync(patientId);
            return Ok(invoices);
        }

        // POST: api/Invoices
        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice([FromBody] Invoice invoice)
        {
            if (invoice == null)
                return BadRequest("Invoice cannot be null.");

            var createdInvoice = await _invoiceService.CreateInvoiceAsync(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = createdInvoice.InvoiceId }, createdInvoice);
        }

        // PUT: api/Invoices/5/Status
        [HttpPut("{id:int}/Status")]
        public async Task<ActionResult<Invoice>> UpdateInvoiceStatus(int id, [FromBody] string status)
        {
            if (string.IsNullOrEmpty(status))
                return BadRequest("Status cannot be empty.");

            var updatedInvoice = await _invoiceService.UpdateInvoiceStatusAsync(id, status);
            return Ok(updatedInvoice);
        }
    }
}
