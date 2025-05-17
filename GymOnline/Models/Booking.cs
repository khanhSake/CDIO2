using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymOnline.Models;

[Table("BOOKINGS")]
[Index("BookingStatus", Name = "IX_BOOKINGS_BookingStatus")]
[Index("PaymentStatus", Name = "IX_BOOKINGS_PaymentStatus")]
[Index("BookingNumber", Name = "UQ__BOOKINGS__AAC320BF0C27469B", IsUnique = true)]
public partial class Booking
{
    [Key]
    [Column("BookingID")]
    public int BookingId { get; set; }

    [StringLength(20)]
    public string? BookingNumber { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [Column("PackageID")]
    public int? PackageId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BookingDate { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal OriginalPrice { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? DiscountAmount { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal TotalAmount { get; set; }

    [StringLength(20)]
    public string BookingStatus { get; set; } = null!;

    [StringLength(20)]
    public string PaymentStatus { get; set; } = null!;

    [StringLength(255)]
    public string? CancellationReason { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Bookings")]
    public virtual GymBranch? Branch { get; set; }

    [ForeignKey("PackageId")]
    [InverseProperty("Bookings")]
    public virtual MembershipPackage? Package { get; set; }

    [InverseProperty("Booking")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [InverseProperty("Booking")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("UserId")]
    [InverseProperty("Bookings")]
    public virtual User? User { get; set; }
}
