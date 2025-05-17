using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystem.Models;

[Table("MEMBERSHIP_PACKAGES")]
[Index("IsPopular", Name = "IX_MEMBERSHIP_PACKAGES_IsPopular")]
public partial class MembershipPackage
{
    [Key]
    [Column("PackageID")]
    public int PackageId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [StringLength(100)]
    public string PackageName { get; set; } = null!;

    public int Duration { get; set; }

    [StringLength(20)]
    public string DurationType { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? DiscountedPrice { get; set; }

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [Column(TypeName = "ntext")]
    public string? Features { get; set; }

    public bool? IsPopular { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Package")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [ForeignKey("BranchId")]
    [InverseProperty("MembershipPackages")]
    public virtual GymBranch? Branch { get; set; }
}
