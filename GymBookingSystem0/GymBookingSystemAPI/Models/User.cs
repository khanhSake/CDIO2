namespace GymBookingSystemAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }

        public List<Review> Reviews { get; set; }
        public List<GymProvider> GymProviders { get; set; } // Thêm thuộc tính này
    }
}