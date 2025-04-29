using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using GymWebsite.Models;
using GymWebsite.Data;          
using BCrypt.Net;              
using System.Data.Entity;       

namespace GymWebsite.Controllers
{
    public class AccountController : BaseController
    {

        [HttpGet]
        public PartialViewResult Register()
        {
            return PartialView("_RegisterPartial", new RegisterModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel m)
        {
            if (!ModelState.IsValid)
                return PartialView("_RegisterPartial", m);
            bool exists = await _context.Users
                .AnyAsync(u => u.Username == m.Username || u.Email == m.Email);
            if (exists)
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc email đã tồn tại.");
                return PartialView("_RegisterPartial", m);
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(m.Password);
            var user = new User
            {
                Username = m.Username,
                Password = passwordHash,
                Email = m.Email,
                FullName = m.FullName,
                PhoneNumber = m.PhoneNumber,
                Address = m.Address,
                DateOfBirth = m.DateOfBirth,
                Gender = m.Gender,
                CreatedAt = DateTime.Now,
                UserType = "Member",
                IsActive = true
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}
