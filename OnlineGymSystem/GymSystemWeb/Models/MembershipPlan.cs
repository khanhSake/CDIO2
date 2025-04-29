using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymSystemWeb.Models
{
    public class MembershipPlan
    {
        public int PlanID { get; set; }

        [Required(ErrorMessage = "Tên gói tập là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên gói tập không được vượt quá 100 ký tự")]
        public string PlanName { get; set; }

        [Required(ErrorMessage = "Thời hạn gói tập là bắt buộc")]
        [Range(1, 36, ErrorMessage = "Thời hạn gói tập phải từ 1-36 tháng")]
        public int Duration { get; set; } // In months

        [Required(ErrorMessage = "Giá gói tập là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá gói tập không được âm")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        // Navigation properties
        public virtual ICollection<PlanBenefit> Benefits { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
} 