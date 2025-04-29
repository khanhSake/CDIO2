using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymSystemWeb.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3-50 ký tự")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(128, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [StringLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự")]
        public string FullName { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Loại người dùng là bắt buộc")]
        public string UserType { get; set; } // Admin, Member, Trainer

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }
        
        public string ProfileImage { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public bool IsActive { get; set; }

        // Navigation properties
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<ClassBooking> ClassBookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual Trainer TrainerProfile { get; set; }
    }
} 