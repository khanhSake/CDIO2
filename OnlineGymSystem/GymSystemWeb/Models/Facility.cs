using System;
using System.ComponentModel.DataAnnotations;

namespace GymSystemWeb.Models
{
    public class Facility
    {
        public int FacilityID { get; set; }
        
        public int BranchID { get; set; }
        
        [Required(ErrorMessage = "Tên tiện ích là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên tiện ích không được vượt quá 100 ký tự")]
        public string FacilityName { get; set; }
        
        public string Description { get; set; }
        
        public string IconClass { get; set; }
        
        // Navigation property
        public virtual GymBranch Branch { get; set; }
    }
} 