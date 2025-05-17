using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystem.Models;

[Table("REVIEWS")]
public partial class Review
{
    [Key]
    [Column("ReviewID")]
    public int ReviewId { get; set; }

    [Column("BookingID")]
    public int? BookingId { get; set; }

    [Column("PTSessionID")]
    public int? PtsessionId { get; set; }

    [Column("ClassBookingID")]
    public int? ClassBookingId { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [Column("TrainerID")]
    public int? TrainerId { get; set; }

    public int Rating { get; set; }

    [Column(TypeName = "ntext")]
    public string? Comment { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReviewDate { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("Reviews")]
    public virtual Booking? Booking { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Reviews")]
    public virtual GymBranch? Branch { get; set; }

    [ForeignKey("ClassBookingId")]
    [InverseProperty("Reviews")]
    public virtual ClassBooking? ClassBooking { get; set; }

    [ForeignKey("PtsessionId")]
    [InverseProperty("Reviews")]
    public virtual PtSession? Ptsession { get; set; }

    [ForeignKey("TrainerId")]
    [InverseProperty("Reviews")]
    public virtual Trainer? Trainer { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Reviews")]
    public virtual User? User { get; set; }
}
