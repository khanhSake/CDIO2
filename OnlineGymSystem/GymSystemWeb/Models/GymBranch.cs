using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymSystemWeb.Models
{
    public class GymBranch
    {
        public int BranchID { get; set; }

        [Required(ErrorMessage = "Tên chi nhánh là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên chi nhánh không được vượt quá 100 ký tự")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Thành phố là bắt buộc")]
        public string City { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        public string OpeningHours { get; set; }

        public string Description { get; set; }

        public string MapLocation { get; set; }

        [Range(0, 5, ErrorMessage = "Đánh giá phải từ 0-5 sao")]
        public decimal Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        // Navigation properties
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<BranchImage> Images { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
} 