using MediTrack.DTOs;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/Payments/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PaymentDto>> GetPaymentById(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        // GET: api/Payments/Invoice/5
        [HttpGet("Invoice/{invoiceId:int}")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPaymentsByInvoice(int invoiceId)
        {
            var payments = await _paymentService.GetPaymentsByInvoiceAsync(invoiceId);
            return Ok(payments);
        }

        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<PaymentDto>> CreatePayment([FromBody] CreatePaymentDto dto)
        {
            if (dto == null)
                return BadRequest("Payment cannot be null.");

            var createdPayment = await _paymentService.CreatePaymentAsync(dto);
            return CreatedAtAction(nameof(GetPaymentById), new { id = createdPayment.PaymentId }, createdPayment);
        }

        // PUT: api/Payments/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PaymentDto>> UpdatePayment(int id, [FromBody] UpdatePaymentDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid payment data.");

            var updatedPayment = await _paymentService.UpdatePaymentAsync(id, dto);
            if (updatedPayment == null)
                return NotFound();

            return Ok(updatedPayment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePayment(int id)
        {
            var result = await _paymentService.DeletePaymentAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
