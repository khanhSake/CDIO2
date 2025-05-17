using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymOnline.Models;

[Table("GYM_BRANCHES")]
[Index("City", Name = "IX_GYM_BRANCHES_City")]
[Index("Featured", Name = "IX_GYM_BRANCHES_Featured")]
public partial class GymBranch
{
    [Key]
    [Column("BranchID")]
    public int BranchId { get; set; }

    [Column("ProviderID")]
    public int? ProviderId { get; set; }

    [StringLength(100)]
    public string BranchName { get; set; } = null!;

    [StringLength(255)]
    public string Address { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [StringLength(50)]
    public string District { get; set; } = null!;

    [StringLength(20)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(100)]
    public string? OpeningHours { get; set; }

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [StringLength(255)]
    public string? MapLocation { get; set; }

    [Column(TypeName = "decimal(10, 8)")]
    public decimal? Latitude { get; set; }

    [Column(TypeName = "decimal(11, 8)")]
    public decimal? Longitude { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal? RatingAverage { get; set; }

    public int? ReviewCount { get; set; }

    public bool? Featured { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Branch")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("Branch")]
    public virtual ICollection<BranchImage> BranchImages { get; set; } = new List<BranchImage>();

    [InverseProperty("Branch")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [InverseProperty("Branch")]
    public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();

    [InverseProperty("Branch")]
    public virtual ICollection<MembershipPackage> MembershipPackages { get; set; } = new List<MembershipPackage>();

    [InverseProperty("Branch")]
    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    [ForeignKey("ProviderId")]
    [InverseProperty("GymBranches")]
    public virtual GymProvider? Provider { get; set; }

    [InverseProperty("Branch")]
    public virtual ICollection<PtSession> PtSessions { get; set; } = new List<PtSession>();

    [InverseProperty("Branch")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("Branch")]
    public virtual ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
}
