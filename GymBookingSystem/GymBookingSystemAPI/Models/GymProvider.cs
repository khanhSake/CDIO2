namespace GymBookingSystemAPI.Models
{
    public class GymProvider
    {
        public int ProviderID { get; set; }
        public int UserID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public bool VerificationStatus { get; set; }
        public bool IsActive { get; set; }

        public User User { get; set; }
        public List<GymBranch> Branches { get; set; }
    }
}