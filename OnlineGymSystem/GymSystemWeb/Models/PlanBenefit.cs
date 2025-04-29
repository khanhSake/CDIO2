using System;
using System.ComponentModel.DataAnnotations;

namespace GymSystemWeb.Models
{
    public class PlanBenefit
    {
        public int BenefitID { get; set; }
        
        public int PlanID { get; set; }
        
        [Required(ErrorMessage = "Mô tả quyền lợi là bắt buộc")]
        public string BenefitDescription { get; set; }
        
        // Navigation property
        public virtual MembershipPlan Plan { get; set; }
    }
} 