namespace GymBookingSystemAPI.Models
{
    public class MembershipPackage
    {
        public int PackageID { get; set; }
        public int BranchID { get; set; }
        public string PackageName { get; set; }
        public int Duration { get; set; }
        public string DurationType { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public bool IsPopular { get; set; }
        public bool IsActive { get; set; }

        public GymBranch Branch { get; set; }
    }
}