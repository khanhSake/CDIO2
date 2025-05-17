namespace GymBookingSystemAPI.DTOs
{
    public class AddBranchImageDTO
    {
        public int BranchID { get; set; }
        public string ImageURL { get; set; }
        public string Caption { get; set; }
        public bool IsMainImage { get; set; }
        public int DisplayOrder { get; set; }
    }
}