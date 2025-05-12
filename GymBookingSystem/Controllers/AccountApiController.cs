using GymBookingSystem.Data;
using GymBookingSystem.Dtos;
using GymBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace GymBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly GymBookingSystemContext _context;

        public AccountApiController(GymBookingSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Đăng ký tài khoản mới
        /// </summary>
        [HttpPost("Register")]
        [ProducesResponseType(typeof(ApiResponseDto), 200)]
        [ProducesResponseType(typeof(ApiResponseDto), 400)]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            // 1. Kiểm tra model
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(kv => kv.Value.Errors.Count > 0)
                    .ToDictionary(
                       kv => kv.Key,
                       kv => kv.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new ApiResponseDto
                {
                    Success = false,
                    Message = "Dữ liệu không hợp lệ.",
                    Errors = errors
                });
            }

            // 2. Kiểm tra trùng Email
            bool exists = await _context.Users
                .AnyAsync(u => u.Email == model.Email && u.IsActive == true);

            if (exists)
            {
                return BadRequest(new ApiResponseDto
                {
                    Success = false,
                    Message = "Email đã tồn tại."
                });
            }

            // 3. Hash mật khẩu
            using var sha = SHA256.Create();
            string hashed = Convert.ToBase64String(
                sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password))
            );

            // 4. Tạo User mới
            var user = new User
            {
                Email = model.Email,
                Password = hashed,
                Username = model.Email,
                FullName = string.Empty,
                UserType = "Customer",
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // 5. Kết quả thành công
            return Ok(new ApiResponseDto
            {
                Success = true,
                Message = "Đăng ký thành công!"
            });
        }
    }
}
