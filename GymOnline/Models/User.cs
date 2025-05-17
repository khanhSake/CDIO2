using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymOnline.Models;

[Table("USERS")]
[Index("UserType", Name = "IX_USERS_UserType")]
[Index("Username", Name = "UQ__USERS__536C85E4232DBB1F", IsUnique = true)]
[Index("Email", Name = "UQ__USERS__A9D10534E6A93FAE", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string Username { get; set; } = null!;

    [StringLength(128)]
    public string Password { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [StringLength(255)]
    public string? Address { get; set; }

    [StringLength(20)]
    public string UserType { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    [StringLength(10)]
    public string? Gender { get; set; }

    [StringLength(255)]
    public string? ProfileImage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("User")]
    public virtual ICollection<ClassBooking> ClassBookings { get; set; } = new List<ClassBooking>();

    [InverseProperty("User")]
    public virtual ICollection<GymProvider> GymProviders { get; set; } = new List<GymProvider>();

    [InverseProperty("User")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [InverseProperty("User")]
    public virtual ICollection<PtSession> PtSessions { get; set; } = new List<PtSession>();

    [InverseProperty("User")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("User")]
    public virtual ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
}
