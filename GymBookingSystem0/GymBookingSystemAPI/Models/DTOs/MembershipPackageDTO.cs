namespace GymBookingSystemAPI.Models.DTOs
{
    public class MembershipPackageDTO
    {
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public int Duration { get; set; }
        public string DurationType { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public bool IsPopular { get; set; }
    }
}
