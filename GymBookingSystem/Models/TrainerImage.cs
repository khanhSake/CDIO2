using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystem.Models;

[Table("TRAINER_IMAGES")]
public partial class TrainerImage
{
    [Key]
    [Column("ImageID")]
    public int ImageId { get; set; }

    [Column("TrainerID")]
    public int? TrainerId { get; set; }

    [Column("ImageURL")]
    [StringLength(255)]
    public string ImageUrl { get; set; } = null!;

    [StringLength(255)]
    public string? Caption { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("TrainerId")]
    [InverseProperty("TrainerImages")]
    public virtual Trainer? Trainer { get; set; }
}
