using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystem.Models;

[Table("GYM_PROVIDERS")]
public partial class GymProvider
{
    [Key]
    [Column("ProviderID")]
    public int ProviderId { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [StringLength(100)]
    public string CompanyName { get; set; } = null!;

    [StringLength(100)]
    public string ContactName { get; set; } = null!;

    [StringLength(20)]
    public string ContactPhone { get; set; } = null!;

    [StringLength(100)]
    public string ContactEmail { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [StringLength(255)]
    public string? Logo { get; set; }

    public bool? VerificationStatus { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal? RatingAverage { get; set; }

    public int? ReviewCount { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Provider")]
    public virtual ICollection<GymBranch> GymBranches { get; set; } = new List<GymBranch>();

    [InverseProperty("Provider")]
    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    [ForeignKey("UserId")]
    [InverseProperty("GymProviders")]
    public virtual User? User { get; set; }
}
