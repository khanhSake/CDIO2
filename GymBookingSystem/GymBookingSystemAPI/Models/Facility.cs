namespace GymBookingSystemAPI.Models
{
    public class Facility
    {
        public int FacilityID { get; set; }
        public int BranchID { get; set; }
        public string FacilityName { get; set; }
        public string Description { get; set; }
        public string IconClass { get; set; }
        public bool IsActive { get; set; }

        public GymBranch Branch { get; set; }
    }
}