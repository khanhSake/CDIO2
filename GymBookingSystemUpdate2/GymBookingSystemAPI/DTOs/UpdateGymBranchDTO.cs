namespace GymBookingSystemAPI.DTOs
{
    public class UpdateGymBranchDTO
    {
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
    }
}