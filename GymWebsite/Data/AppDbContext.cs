using System.Collections.Generic;
using System.Data.Entity;
using GymWebsite.Models; 

namespace GymWebsite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("DefaultConnection") 
        {
        }

        public DbSet<User> Users { get; set; }
        //sau này mấy fen muốn dùng dữ liệu bảng nào thì bỏ dấu ghi chú bảng đó rồi vào Models tạo class cho bảng mấy fen muốn như bảng user
        //public DbSet<GYM_PROVIDERS> GymProviders { get; set; }
        //public DbSet<GYM_BRANCHES> GymBranches { get; set; }
        //public DbSet<FACILITIES> Facilities { get; set; }
        //public DbSet<BRANCH_IMAGES> BranchImages { get; set; }
        //public DbSet<MEMBERSHIP_PACKAGES> MembershipPackages { get; set; }
        //public DbSet<TRAINERS> Trainers { get; set; }
        //public DbSet<TRAINER_IMAGES> TrainerImages { get; set; }
        //public DbSet<CLASSES> Classes { get; set; }
        //public DbSet<CLASS_SCHEDULE> ClassSchedules { get; set; }
        //public DbSet<BOOKINGS> Bookings { get; set; }
        //public DbSet<CLASS_BOOKINGS> ClassBookings { get; set; }
        //public DbSet<PT_SESSIONS> PTSessions { get; set; }
        //public DbSet<REVIEWS> Reviews { get; set; }
        //public DbSet<PAYMENTS> Payments { get; set; }
        //public DbSet<PROMOTIONS> Promotions { get; set; }
    }
}
