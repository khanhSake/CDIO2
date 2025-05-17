using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymOnline.Data;
using GymOnline.Models;

namespace GymOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly GymContext _context;

        public PaymentController(GymContext context)
        {
            _context = context;
        }

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult<Payment>> CreatePayment(Payment payment)
        {
            payment.PaymentDate = DateTime.UtcNow;
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentId }, payment);
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();

            return payment;
        }

        // PUT: api/Payment/5 (Update status)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentStatus(int id, [FromBody] string status)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();

            payment.Status = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
