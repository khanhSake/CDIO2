using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymOnline.Models;

[Table("TRAINERS")]
public partial class Trainer
{
    [Key]
    [Column("TrainerID")]
    public int TrainerId { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [StringLength(255)]
    public string? ProfileImage { get; set; }

    [StringLength(100)]
    public string? Specialization { get; set; }

    public int? Experience { get; set; }

    [Column(TypeName = "ntext")]
    public string? Bio { get; set; }

    [Column(TypeName = "ntext")]
    public string? Certifications { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? HourlyRate { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal? RatingAverage { get; set; }

    public int? ReviewCount { get; set; }

    public bool? IsAvailable { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Trainers")]
    public virtual GymBranch? Branch { get; set; }

    [InverseProperty("Trainer")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [InverseProperty("Trainer")]
    public virtual ICollection<PtSession> PtSessions { get; set; } = new List<PtSession>();

    [InverseProperty("Trainer")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("Trainer")]
    public virtual ICollection<TrainerImage> TrainerImages { get; set; } = new List<TrainerImage>();

    [ForeignKey("UserId")]
    [InverseProperty("Trainers")]
    public virtual User? User { get; set; }
}
