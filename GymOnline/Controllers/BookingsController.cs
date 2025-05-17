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
    public class BookingsController : ControllerBase
    {
        private readonly GymContext _context;

        public BookingsController(GymContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking([FromBody] dynamic request)
        {
            // Lấy packageId và startDate từ request
            int packageId;
            DateOnly startDate;

            try
            {
                packageId = (int)request.packageId;
                startDate = DateOnly.Parse((string)request.startDate);
            }
            catch (Exception ex)
            {
                return BadRequest("Dữ liệu đầu vào không hợp lệ: " + ex.Message);
            }

            // Kiểm tra ngày bắt đầu không được trong quá khứ
            if (startDate < DateOnly.FromDateTime(DateTime.Today))
            {
                return BadRequest("Ngày bắt đầu không được là ngày trong quá khứ.");
            }

            // Kiểm tra gói tập có tồn tại và đang hoạt động
            var package = await _context.MembershipPackages
                .FirstOrDefaultAsync(p => p.PackageId == packageId && p.IsActive == true);
            if (package == null)
            {
                return NotFound("Gói tập không tồn tại hoặc không hoạt động.");
            }

            // Kiểm tra chi nhánh của gói tập
            if (!package.BranchId.HasValue)
            {
                return BadRequest("Gói tập không thuộc chi nhánh nào.");
            }

            var branch = await _context.GymBranches
                .FirstOrDefaultAsync(b => b.BranchId == package.BranchId && b.IsActive == true);
            if (branch == null)
            {
                return NotFound("Chi nhánh không tồn tại hoặc không hoạt động.");
            }

            // Tính EndDate dựa trên Duration và DurationType
            int durationInDays = package.DurationType.ToLower() switch
            {
                "days" => package.Duration,
                "weeks" => package.Duration * 7,
                "months" => package.Duration * 30,
                "years" => package.Duration * 365,
                _ => 0
            };
            var endDate = startDate.AddDays(durationInDays);

            if (endDate <= startDate)
            {
                return BadRequest("Ngày kết thúc không hợp lệ.");
            }

            // Tạo BookingNumber duy nhất
            var today = DateTime.Today;
            var bookingCount = await _context.Bookings
                .CountAsync(b => b.BookingDate.Date == today);
            var bookingNumber = $"BK{today:yyyyMMdd}{bookingCount + 1:D4}";

            // Tính toán giá
            var originalPrice = package.Price;
            var discountAmount = package.DiscountedPrice.HasValue
                ? package.Price - package.DiscountedPrice.Value
                : 0m;
            var totalAmount = package.DiscountedPrice ?? package.Price;

            // Tạo Booking mới
            var booking = new Booking
            {
                BookingNumber = bookingNumber,
                UserId = 3,
                PackageId = packageId,
                BranchId = package.BranchId.Value,
                BookingDate = DateTime.Now,
                StartDate = startDate,
                EndDate = endDate,
                OriginalPrice = originalPrice,
                DiscountAmount = discountAmount,
                TotalAmount = totalAmount,
                BookingStatus = "Pending",
                PaymentStatus = "Unpaid",
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // Tải lại booking với thông tin Package và Branch
            var createdBooking = await _context.Bookings
                .Include(b => b.Package)
                .Include(b => b.Branch)
                .FirstOrDefaultAsync(b => b.BookingId == booking.BookingId);

            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, createdBooking);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Package)
                .Include(b => b.Branch)
                .FirstOrDefaultAsync(b => b.BookingId == id && b.IsActive == true);

            if (booking == null)
            {
                return NotFound("Đặt chỗ không tồn tại hoặc không hoạt động.");
            }

            return Ok(booking);
        }

        [HttpGet("booking-number/{bookingNumber}")]
        public async Task<ActionResult<Booking>> GetBookingByNumber(string bookingNumber)
        {
            var booking = await _context.Bookings
                .Include(b => b.Package)
                .Include(b => b.Branch)
                .FirstOrDefaultAsync(b => b.BookingNumber == bookingNumber && b.IsActive == true);

            if (booking == null)
            {
                return NotFound("Đặt chỗ không tồn tại hoặc không hoạt động.");
            }

            return Ok(booking);
        }
    }
}