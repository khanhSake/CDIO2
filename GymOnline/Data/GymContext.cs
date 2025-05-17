using System;
using System.Collections.Generic;
using GymOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace GymOnline.Data;

public partial class GymContext : DbContext
{
    public GymContext()
    {
    }

    public GymContext(DbContextOptions<GymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BranchImage> BranchImages { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassBooking> ClassBookings { get; set; }

    public virtual DbSet<ClassSchedule> ClassSchedules { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<GymBranch> GymBranches { get; set; }

    public virtual DbSet<GymProvider> GymProviders { get; set; }

    public virtual DbSet<MembershipPackage> MembershipPackages { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<PtSession> PtSessions { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<TrainerImage> TrainerImages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=GymBookingSystem;User Id=sa;Password=123456;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__BOOKINGS__73951ACDD5FB6DFA");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DiscountAmount).HasDefaultValue(0m);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Branch).WithMany(p => p.Bookings).HasConstraintName("FK__BOOKINGS__Branch__70DDC3D8");

            entity.HasOne(d => d.Package).WithMany(p => p.Bookings).HasConstraintName("FK__BOOKINGS__Packag__6FE99F9F");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings).HasConstraintName("FK__BOOKINGS__UserID__6EF57B66");
        });

        modelBuilder.Entity<BranchImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__BRANCH_I__7516F4EC497EB637");

            entity.Property(e => e.DisplayOrder).HasDefaultValue(0);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsMainImage).HasDefaultValue(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.BranchImages).HasConstraintName("FK__BRANCH_IM__Branc__4E88ABD4");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__CLASSES__CB1927A0BFB3B92B");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Branch).WithMany(p => p.Classes).HasConstraintName("FK__CLASSES__BranchI__656C112C");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Classes).HasConstraintName("FK__CLASSES__Trainer__66603565");
        });

        modelBuilder.Entity<ClassBooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__CLASS_BO__73951ACDB1592653");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Schedule).WithMany(p => p.ClassBookings).HasConstraintName("FK__CLASS_BOO__Sched__778AC167");

            entity.HasOne(d => d.User).WithMany(p => p.ClassBookings).HasConstraintName("FK__CLASS_BOO__UserI__76969D2E");
        });

        modelBuilder.Entity<ClassSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__CLASS_SC__9C8A5B691D7A6135");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSchedules).HasConstraintName("FK__CLASS_SCH__Class__6A30C649");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.FacilityId).HasName("PK__FACILITI__5FB08B9477B131AF");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Branch).WithMany(p => p.Facilities).HasConstraintName("FK__FACILITIE__Branc__4AB81AF0");
        });

        modelBuilder.Entity<GymBranch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__GYM_BRAN__A1682FA556191CF3");

            entity.Property(e => e.Featured).HasDefaultValue(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RatingAverage).HasDefaultValue(0m);
            entity.Property(e => e.ReviewCount).HasDefaultValue(0);

            entity.HasOne(d => d.Provider).WithMany(p => p.GymBranches).HasConstraintName("FK__GYM_BRANC__Provi__440B1D61");
        });

        modelBuilder.Entity<GymProvider>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("PK__GYM_PROV__B54C689DDE4C575F");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RatingAverage).HasDefaultValue(0m);
            entity.Property(e => e.ReviewCount).HasDefaultValue(0);
            entity.Property(e => e.VerificationStatus).HasDefaultValue(false);

            entity.HasOne(d => d.User).WithMany(p => p.GymProviders).HasConstraintName("FK__GYM_PROVI__UserI__3D5E1FD2");
        });

        modelBuilder.Entity<MembershipPackage>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__MEMBERSH__322035EC803F81FC");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsPopular).HasDefaultValue(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.MembershipPackages).HasConstraintName("FK__MEMBERSHI__Branc__5441852A");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__PAYMENTS__9B556A58E2D7E768");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments).HasConstraintName("FK__PAYMENTS__Bookin__114A936A");

            entity.HasOne(d => d.Ptsession).WithMany(p => p.Payments).HasConstraintName("FK__PAYMENTS__PTSess__123EB7A3");

            entity.HasOne(d => d.User).WithMany(p => p.Payments).HasConstraintName("FK__PAYMENTS__UserID__10566F31");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__PROMOTIO__52C42F2FCABA2DD5");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Branch).WithMany(p => p.Promotions).HasConstraintName("FK__PROMOTION__Branc__18EBB532");

            entity.HasOne(d => d.Provider).WithMany(p => p.Promotions).HasConstraintName("FK__PROMOTION__Provi__17F790F9");
        });

        modelBuilder.Entity<PtSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__PT_SESSI__C9F4927026B5F067");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DiscountAmount).HasDefaultValue(0m);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Branch).WithMany(p => p.PtSessions).HasConstraintName("FK__PT_SESSIO__Branc__7F2BE32F");

            entity.HasOne(d => d.Trainer).WithMany(p => p.PtSessions).HasConstraintName("FK__PT_SESSIO__Train__7E37BEF6");

            entity.HasOne(d => d.User).WithMany(p => p.PtSessions).HasConstraintName("FK__PT_SESSIO__UserI__7D439ABD");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__REVIEWS__74BC79AE379D0AD6");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsApproved).HasDefaultValue(false);
            entity.Property(e => e.ReviewDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Booking).WithMany(p => p.Reviews).HasConstraintName("FK__REVIEWS__Booking__04E4BC85");

            entity.HasOne(d => d.Branch).WithMany(p => p.Reviews).HasConstraintName("FK__REVIEWS__BranchI__08B54D69");

            entity.HasOne(d => d.ClassBooking).WithMany(p => p.Reviews).HasConstraintName("FK__REVIEWS__ClassBo__06CD04F7");

            entity.HasOne(d => d.Ptsession).WithMany(p => p.Reviews).HasConstraintName("FK__REVIEWS__PTSessi__05D8E0BE");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Reviews).HasConstraintName("FK__REVIEWS__Trainer__09A971A2");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews).HasConstraintName("FK__REVIEWS__UserID__07C12930");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__TRAINERS__366A1B9C6FA358F2");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.RatingAverage).HasDefaultValue(0m);
            entity.Property(e => e.ReviewCount).HasDefaultValue(0);

            entity.HasOne(d => d.Branch).WithMany(p => p.Trainers).HasConstraintName("FK__TRAINERS__Branch__59FA5E80");

            entity.HasOne(d => d.User).WithMany(p => p.Trainers).HasConstraintName("FK__TRAINERS__UserID__59063A47");
        });

        modelBuilder.Entity<TrainerImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__TRAINER___7516F4ECC201A608");

            entity.Property(e => e.DisplayOrder).HasDefaultValue(0);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Trainer).WithMany(p => p.TrainerImages).HasConstraintName("FK__TRAINER_I__Train__60A75C0F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USERS__1788CCAC515CD83B");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
