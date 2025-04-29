using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymSystemWeb.Models
{
    // ViewModel for displaying branch details with related data
    public class GymBranchDetailViewModel
    {
        public GymBranch Branch { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<BranchImage> Images { get; set; }
        public List<TrainerViewModel> Trainers { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
        public List<MembershipPlan> MembershipPlans { get; set; }
    }

    // ViewModel for displaying trainer information
    public class TrainerViewModel
    {
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
    }

    // ViewModel for displaying review information
    public class ReviewViewModel
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
    }

    // ViewModel for user registration
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3-50 ký tự")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(128, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        public string FullName { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }
    }

    // ViewModel for user login
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    // ViewModel for subscription purchase
    public class SubscriptionViewModel
    {
        public int PlanID { get; set; }
        public int BranchID { get; set; }
        public DateTime StartDate { get; set; }
        public string PaymentMethod { get; set; }
    }

    // ViewModel for search results
    public class SearchResultViewModel
    {
        public string SearchText { get; set; }
        public List<GymBranch> Branches { get; set; }
    }
} 