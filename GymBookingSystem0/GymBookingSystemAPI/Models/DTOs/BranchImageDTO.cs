namespace GymBookingSystemAPI.Models.DTOs
{
    public class BranchImageDTO
    {
        public int ImageID { get; set; }
        public string ImageURL { get; set; }
        public string Caption { get; set; }
        public bool IsMainImage { get; set; }
    }
}
