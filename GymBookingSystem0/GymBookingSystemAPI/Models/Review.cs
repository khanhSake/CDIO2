namespace GymBookingSystemAPI.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int? BookingID { get; set; }
        public int? PTSessionID { get; set; }
        public int? ClassBookingID { get; set; }
        public int UserID { get; set; }
        public int? BranchID { get; set; }
        public int? TrainerID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }

        public User User { get; set; }
        public GymBranch Branch { get; set; }
    }
}