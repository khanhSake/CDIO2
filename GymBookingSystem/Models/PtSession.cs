using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystem.Models;

[Table("PT_SESSIONS")]
[Index("BookingNumber", Name = "UQ__PT_SESSI__AAC320BF59C242B3", IsUnique = true)]
public partial class PtSession
{
    [Key]
    [Column("SessionID")]
    public int SessionId { get; set; }

    [StringLength(20)]
    public string? BookingNumber { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [Column("TrainerID")]
    public int? TrainerId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    public DateOnly SessionDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? DiscountAmount { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal TotalAmount { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;

    [StringLength(20)]
    public string PaymentStatus { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Notes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("PtSessions")]
    public virtual GymBranch? Branch { get; set; }

    [InverseProperty("Ptsession")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [InverseProperty("Ptsession")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("TrainerId")]
    [InverseProperty("PtSessions")]
    public virtual Trainer? Trainer { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("PtSessions")]
    public virtual User? User { get; set; }
}
