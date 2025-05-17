using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymOnline.Models;

[Table("CLASSES")]
public partial class Class
{
    [Key]
    [Column("ClassID")]
    public int ClassId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [StringLength(100)]
    public string ClassName { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [StringLength(50)]
    public string? ClassType { get; set; }

    [Column("TrainerID")]
    public int? TrainerId { get; set; }

    public int MaxCapacity { get; set; }

    public int DurationMinutes { get; set; }

    [StringLength(20)]
    public string? DifficultyLevel { get; set; }

    [StringLength(255)]
    public string? ClassImage { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Classes")]
    public virtual GymBranch? Branch { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();

    [ForeignKey("TrainerId")]
    [InverseProperty("Classes")]
    public virtual Trainer? Trainer { get; set; }
}
