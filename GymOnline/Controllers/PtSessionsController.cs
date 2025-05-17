using GymOnline.Data;
using GymOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GymOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PTSessionsController : ControllerBase
    {
        private readonly GymContext _context;

        public PTSessionsController(GymContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<PtSession>> CreatePTSession([FromBody] PtSession ptSession)
        {
            if (ptSession == null || ptSession.TrainerId <= 0 || ptSession.BranchId <= 0)
            {
                return BadRequest("Thông tin không hợp lệ.");
            }

            var trainer = await _context.Trainers.FindAsync(ptSession.TrainerId);
            if (trainer == null)
            {
                return NotFound("Huấn luyện viên không tồn tại.");
            }

            TimeSpan duration = ptSession.EndTime.ToTimeSpan() - ptSession.StartTime.ToTimeSpan();
            double hours = duration.TotalHours;
            if (hours <= 0)
            {
                return BadRequest("Thời gian buổi tập không hợp lệ.");
            }

            decimal price = trainer.HourlyRate.GetValueOrDefault(0) * (decimal)hours;

            ptSession.BookingNumber = "PT" + DateTime.Now.Ticks.ToString();
            ptSession.Price = price;
            ptSession.DiscountAmount = 0;
            ptSession.TotalAmount = price;
            ptSession.Status = "Booked";
            ptSession.PaymentStatus = "Unpaid";
            ptSession.CreatedAt = DateTime.Now;
            ptSession.IsActive = true;

            _context.PtSessions.Add(ptSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPTSession), new { id = ptSession.SessionId }, ptSession);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PtSession>> GetPTSession(int id)
        {
            var ptSession = await _context.PtSessions.FindAsync(id);
            if (ptSession == null)
            {
                return NotFound();
            }
            return ptSession;
        }

        [HttpPut("update-payment/{bookingNumber}")]
        public async Task<IActionResult> UpdatePaymentStatus(string bookingNumber, [FromBody] PaymentUpdateRequest request)
        {
            var ptSession = await _context.PtSessions
                .FirstOrDefaultAsync(s => s.BookingNumber == bookingNumber);

            if (ptSession == null)
            {
                return NotFound("Không tìm thấy buổi tập.");
            }

            ptSession.PaymentStatus = request.PaymentStatus;

            await _context.SaveChangesAsync();
            return Ok("Cập nhật trạng thái thanh toán thành công.");
        }
        [HttpGet("{bookingNumber}")]
        public async Task<ActionResult<PtSession>> GetPTSessionByBookingNumber(string bookingNumber)
        {
            var ptSession = await _context.PtSessions
                .FirstOrDefaultAsync(s => s.BookingNumber == bookingNumber);

            if (ptSession == null)
            {
                return NotFound("Không tìm thấy buổi tập với mã đặt lịch này.");
            }
            return ptSession;
        }
    }

    public class PaymentUpdateRequest
    {
        public string PaymentStatus { get; set; }
    }
}