using GymBookingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymBookingSystemAPI.Data
{
    public class GymBookingContext : DbContext
    {
        public GymBookingContext(DbContextOptions<GymBookingContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<GymProvider> GymProviders { get; set; }
        public DbSet<GymBranch> GymBranches { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<BranchImage> BranchImages { get; set; }
        public DbSet<MembershipPackage> MembershipPackages { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình tên bảng
            modelBuilder.Entity<GymBranch>()
                .ToTable("GYM_BRANCHES");

            modelBuilder.Entity<User>()
                .ToTable("USERS");

            modelBuilder.Entity<GymProvider>()
                .ToTable("GYM_PROVIDERS");

            modelBuilder.Entity<Facility>()
                .ToTable("FACILITIES");

            modelBuilder.Entity<BranchImage>()
                .ToTable("BRANCH_IMAGES");

            modelBuilder.Entity<MembershipPackage>()
                .ToTable("MEMBERSHIP_PACKAGES");

            modelBuilder.Entity<Review>()
                .ToTable("REVIEWS");

            // Cấu hình khóa chính
            modelBuilder.Entity<GymBranch>()
                .HasKey(b => b.BranchID);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<GymProvider>()
                .HasKey(gp => gp.ProviderID);

            modelBuilder.Entity<Facility>()
                .HasKey(f => f.FacilityID);

            modelBuilder.Entity<BranchImage>()
                .HasKey(bi => bi.ImageID);

            modelBuilder.Entity<MembershipPackage>()
                .HasKey(mp => mp.PackageID);

            modelBuilder.Entity<Review>()
                .HasKey(r => r.ReviewID);

            // Cấu hình các mối quan hệ
            modelBuilder.Entity<GymBranch>()
                .HasOne(b => b.Provider)
                .WithMany(p => p.Branches)
                .HasForeignKey(b => b.ProviderID);

            modelBuilder.Entity<Facility>()
                .HasOne(f => f.Branch)
                .WithMany(b => b.Facilities)
                .HasForeignKey(f => f.BranchID);

            modelBuilder.Entity<BranchImage>()
                .HasOne(i => i.Branch)
                .WithMany(b => b.BranchImages)
                .HasForeignKey(i => i.BranchID);

            modelBuilder.Entity<MembershipPackage>()
                .HasOne(p => p.Branch)
                .WithMany(b => b.MembershipPackages)
                .HasForeignKey(p => p.BranchID);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Branch)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BranchID);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<GymProvider>()
                .HasOne(gp => gp.User)
                .WithMany(u => u.GymProviders)
                .HasForeignKey(gp => gp.UserID);
        }
    }
}