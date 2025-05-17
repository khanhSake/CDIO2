namespace GymBookingSystemAPI.Models
{
    public class GymBranch
    {
        public int BranchID { get; set; }
        public int ProviderID { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }
        public string Description { get; set; }
        public string MapLocation { get; set; }
        public decimal Latitude { get; set; } 
        public decimal Longitude { get; set; } 
        public decimal RatingAverage { get; set; } 
        public int ReviewCount { get; set; }
        public bool Featured { get; set; }
        public bool IsActive { get; set; }
        public GymProvider Provider { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<BranchImage> BranchImages { get; set; }
        public List<MembershipPackage> MembershipPackages { get; set; }
        public List<Review> Reviews { get; set; }
    }
}