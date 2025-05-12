using System.ComponentModel.DataAnnotations;

namespace GymBookingSystem.Dtos
{
    public class LoginDto
    {
        [Required, EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Mã xác thực")]
        public string Captcha { get; set; } = string.Empty;

        [Display(Name = "Nhớ mật khẩu")]
        public bool RememberMe { get; set; }
    }
}
