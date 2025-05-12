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
    public class LoginController : Controller
    {
        private readonly GymBookingSystemContext _context;
        public LoginController(GymBookingSystemContext context)
        {
            _context = context;
        }

        // GET: /Login
        [HttpGet]
        public IActionResult Index()
        {
            // Tạo Captcha ngẫu nhiên 4 chữ số
            var code = new Random().Next(1000, 9999).ToString();
            HttpContext.Session.SetString("CaptchaCode", code);
            ViewBag.CaptchaCode = code;
            return View();
        }

        // POST: /Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Kiểm tra Captcha
            var sessionCode = HttpContext.Session.GetString("CaptchaCode");
            if (model.Captcha != sessionCode)
            {
                ModelState.AddModelError(nameof(model.Captcha), "Mã xác thực không đúng.");
                return View(model);
            }

            // Tìm user theo Email
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.IsActive == true);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
                return View(model);
            }

            // Hash và so sánh mật khẩu
            using var sha = SHA256.Create();
            var hashed = Convert.ToBase64String(
                sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password))
            );
            if (hashed != user.Password)
            {
                ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
                return View(model);
            }

            // TODO: Thiết lập xác thực (cookie/session) nếu RememberMe = true

            // Đăng nhập thành công: chuyển hướng về trang chủ
            return RedirectToAction("Index", "Home");
        }
    }
}
