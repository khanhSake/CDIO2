using GymBookingSystem.Data;
using GymBookingSystem.Dtos;
using GymBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GymBookingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly GymBookingSystemContext _context;
        public AccountController(GymBookingSystemContext context)
            => _context = context;

        // GET /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            if (TempData["SuccessMessage"] is string msg)
                ViewBag.SuccessMessage = msg;
            return View();
        }

        // POST /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool exists = await _context.Users
                .AnyAsync(u => u.Email == model.Email && u.IsActive == true);
            if (exists)
            {
                ModelState.AddModelError(nameof(model.Email), "Email đã tồn tại.");
                return View(model);
            }

            // Hash password
            string hashedPassword;
            using (var sha = SHA256.Create())
            {
                hashedPassword = Convert.ToBase64String(
                    sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password))
                );
            }

            var user = new User
            {
                Email = model.Email,
                Username = model.Email,
                Password = hashedPassword,
                FullName = model.FullName,
                UserType = "Customer",
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Đăng ký thành công!";
            return RedirectToAction(nameof(Register));
        }
    }
}
