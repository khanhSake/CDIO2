using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystem.Models;

[Table("PAYMENTS")]
public partial class Payment
{
    [Key]
    [Column("PaymentID")]
    public int PaymentId { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [Column("BookingID")]
    public int? BookingId { get; set; }

    [Column("PTSessionID")]
    public int? PtsessionId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    [StringLength(50)]
    public string PaymentMethod { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime PaymentDate { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;

    [Column("TransactionID")]
    [StringLength(100)]
    public string? TransactionId { get; set; }

    [StringLength(255)]
    public string? Notes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("Payments")]
    public virtual Booking? Booking { get; set; }

    [ForeignKey("PtsessionId")]
    [InverseProperty("Payments")]
    public virtual PtSession? Ptsession { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Payments")]
    public virtual User? User { get; set; }
}
