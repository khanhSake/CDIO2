using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymOnline.Models;

[Table("CLASS_BOOKINGS")]
public partial class ClassBooking
{
    [Key]
    [Column("BookingID")]
    public int BookingId { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [Column("ScheduleID")]
    public int? ScheduleId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BookingDate { get; set; }

    public DateOnly ClassDate { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("ClassBooking")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("ScheduleId")]
    [InverseProperty("ClassBookings")]
    public virtual ClassSchedule? Schedule { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ClassBookings")]
    public virtual User? User { get; set; }
}
