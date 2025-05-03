namespace GymBookingSystemAPI.Models.DTOs
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string UserFullName { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
