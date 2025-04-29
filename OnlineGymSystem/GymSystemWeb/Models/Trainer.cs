using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymSystemWeb.Models
{
    public class Trainer
    {
        public int TrainerID { get; set; }
        
        public int UserID { get; set; }
        
        public int BranchID { get; set; }
        
        [Required(ErrorMessage = "Chuyên môn là bắt buộc")]
        public string Specialization { get; set; }
        
        [Range(0, 50, ErrorMessage = "Số năm kinh nghiệm không hợp lệ")]
        public int Experience { get; set; }
        
        public string Bio { get; set; }
        
        [Range(0, double.MaxValue, ErrorMessage = "Giá mỗi giờ không được âm")]
        public decimal HourlyRate { get; set; }
        
        public bool IsAvailable { get; set; }
        
        // Navigation properties
        public virtual User User { get; set; }
        public virtual GymBranch Branch { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<PersonalTrainingSession> TrainingSessions { get; set; }
    }
} 