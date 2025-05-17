using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymOnline.Models;

[Table("CLASS_SCHEDULE")]
public partial class ClassSchedule
{
    [Key]
    [Column("ScheduleID")]
    public int ScheduleId { get; set; }

    [Column("ClassID")]
    public int? ClassId { get; set; }

    public int DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int AvailableSpots { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("ClassSchedules")]
    public virtual Class? Class { get; set; }

    [InverseProperty("Schedule")]
    public virtual ICollection<ClassBooking> ClassBookings { get; set; } = new List<ClassBooking>();
}
