using System;
using System.Linq;
using System.Threading.Tasks;
using GymBookingSystem.Data;
using GymBookingSystem.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystem.Controllers
{
    public class TrainerController : Controller
    {
        private readonly GymBookingSystemContext _context;
        public TrainerController(GymBookingSystemContext context) => _context = context;

        private int GetTrainerId() => 1; // Hard-code hoặc lấy từ Claim

        [HttpGet]
        public async Task<IActionResult> ClassSchedules()
        {
            int tId = GetTrainerId();
            var list = await _context.ClassSchedules
                .Where(s => s.IsActive == true && s.Class!.TrainerId == tId)
                .Select(s => new TrainerClassScheduleDto
                {
                    ScheduleId = s.ScheduleId,
                    ClassName = s.Class.ClassName!,
                    DayOfWeek = s.DayOfWeek,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    AvailableSpots = s.AvailableSpots
                }).ToListAsync();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> PtSessions()
        {
            int tId = GetTrainerId();
            var list = await _context.PtSessions
                .Where(p => p.IsActive == true && p.TrainerId == tId)
                .Include(p => p.User)
                .Select(p => new TrainerPtSessionDto
                {
                    SessionId = p.SessionId,
                    SessionDate = p.SessionDate,
                    StartTime = p.StartTime,
                    EndTime = p.EndTime,
                    ClientEmail = p.User!.Email,
                    TotalAmount = p.TotalAmount,
                    Status = p.Status
                }).ToListAsync();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Students()
        {
            int tId = GetTrainerId();
            var studentIds = await _context.PtSessions
                .Where(p => p.TrainerId == tId)
                .Select(p => p.UserId!.Value)
                .Union(
                    _context.ClassBookings
                      .Where(cb => cb.Schedule!.Class!.TrainerId == tId)
                      .Select(cb => cb.UserId!.Value)
                )
                .Distinct()
                .ToListAsync();

            var students = await _context.Users
                .Where(u => u.IsActive == true && studentIds.Contains(u.UserId))
                .Select(u => new StudentDto
                {
                    UserId = u.UserId,
                    FullName = u.FullName,
                    Email = u.Email,
                    ClassesBooked = _context.ClassBookings.Count(cb => cb.UserId == u.UserId && cb.IsActive == true),
                    PtSessionsBooked = _context.PtSessions.Count(ps => ps.UserId == u.UserId && ps.IsActive == true)
                }).ToListAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Progress(int id)
        {
            ViewBag.StudentName = (await _context.Users.FindAsync(id))?.FullName;
            var prog = await _context.Reviews
                .Where(r => r.UserId == id && r.IsActive == true)
                .Select(r => new StudentProgressDto
                {
                    ClassName = r.ClassBooking != null
                                      ? r.ClassBooking.Schedule!.Class!.ClassName!
                                      : (r.Ptsession != null ? "PT Session" : string.Empty),
                    BookingDate = r.ReviewDate,  // DateTime? → DateTime? OK
                    Status = r.IsApproved == true
                                      ? "Đã duyệt"
                                      : "Chưa duyệt",
                    Rating = r.Rating,
                    Comment = r.Comment
                }).ToListAsync();

            return View(prog);
        }
    }
}
