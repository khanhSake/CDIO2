using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystem.Models;

[Table("FACILITIES")]
public partial class Facility
{
    [Key]
    [Column("FacilityID")]
    public int FacilityId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [StringLength(100)]
    public string FacilityName { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [StringLength(50)]
    public string? IconClass { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Facilities")]
    public virtual GymBranch? Branch { get; set; }
}
