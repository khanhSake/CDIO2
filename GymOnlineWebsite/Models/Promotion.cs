using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystem.Models;

[Table("PROMOTIONS")]
[Index("Code", Name = "IX_PROMOTIONS_Code")]
[Index("Code", Name = "UQ__PROMOTIO__A25C5AA7D73DE3AA", IsUnique = true)]
public partial class Promotion
{
    [Key]
    [Column("PromotionID")]
    public int PromotionId { get; set; }

    [Column("ProviderID")]
    public int? ProviderId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [StringLength(20)]
    public string? Code { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [StringLength(20)]
    public string DiscountType { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal DiscountValue { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [Column(TypeName = "ntext")]
    public string? TermsAndConditions { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Promotions")]
    public virtual GymBranch? Branch { get; set; }

    [ForeignKey("ProviderId")]
    [InverseProperty("Promotions")]
    public virtual GymProvider? Provider { get; set; }
}
