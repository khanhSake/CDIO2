using System;
using System.ComponentModel.DataAnnotations;

namespace GymSystemWeb.Models
{
    public class BranchImage
    {
        public int ImageID { get; set; }
        
        public int BranchID { get; set; }
        
        [Required(ErrorMessage = "URL hình ảnh là bắt buộc")]
        public string ImageURL { get; set; }
        
        public string Caption { get; set; }
        
        public bool IsMainImage { get; set; }
        
        // Navigation property
        public virtual GymBranch Branch { get; set; }
    }
} 