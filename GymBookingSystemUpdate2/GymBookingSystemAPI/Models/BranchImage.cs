namespace GymBookingSystemAPI.Models
{
    public class BranchImage
    {
        public int ImageID { get; set; }
        public int BranchID { get; set; }
        public string ImageURL { get; set; }
        public string Caption { get; set; }
        public bool IsMainImage { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public GymBranch Branch { get; set; }
    }
}