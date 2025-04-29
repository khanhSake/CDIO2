using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystem.Models;

[Table("BRANCH_IMAGES")]
public partial class BranchImage
{
    [Key]
    [Column("ImageID")]
    public int ImageId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [Column("ImageURL")]
    [StringLength(255)]
    public string ImageUrl { get; set; } = null!;

    [StringLength(255)]
    public string? Caption { get; set; }

    public bool? IsMainImage { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("BranchImages")]
    public virtual GymBranch? Branch { get; set; }
}
