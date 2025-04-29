using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BCrypt.Net;
using GymWebsite.Data;
using GymWebsite.Models;

namespace GymWebsite.Controllers
{
    public class LoginController : BaseController
    {

        [HttpGet]
        [AllowAnonymous]
        public FileContentResult CaptchaImage()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rnd = new Random();
            var code = new string(Enumerable.Range(0, 4)
                                 .Select(_ => chars[rnd.Next(chars.Length)])
                                 .ToArray());

            Session["CaptchaCode"] = code;

            using (var bmp = new Bitmap(120, 40))
            using (var g = Graphics.FromImage(bmp))
            using (var font = new Font("Arial", 20, FontStyle.Bold))
            {
                g.Clear(Color.White);
                g.DrawString(code, font, Brushes.Gray, new PointF(10, 5));
                using (var ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Png);
                    return File(ms.ToArray(), "image/png");
                }
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Dữ liệu không hợp lệ." });

            var sess = Session["CaptchaCode"] as string;
            if (string.IsNullOrEmpty(sess) ||
                !model.Captcha.Equals(sess, StringComparison.OrdinalIgnoreCase))
            {
                return Json(new { success = false, message = "Captcha không đúng." });
            }

            var user = _context.Users
                .FirstOrDefault(u => u.Username == model.UserName);
            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return Json(new { success = false, message = "Tên đăng nhập hoặc mật khẩu không đúng." });
            }

            // không lưu url cũ khi đóng trình duyệt(cái này test nha mấy chế, sau mình làm nút đăng xuất thì bỏ nó đi)
            FormsAuthentication.SetAuthCookie(user.Username, false);

            return Json(new { success = true });
        }
    }
}
