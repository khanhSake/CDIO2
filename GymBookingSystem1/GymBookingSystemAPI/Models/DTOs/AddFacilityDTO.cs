namespace GymBookingSystemAPI.Models.DTOs
{
    public class AddFacilityDTO
    {
        public int BranchID { get; set; }
        public string FacilityName { get; set; }
        public string Description { get; set; }
        public string IconClass { get; set; }
    }
}