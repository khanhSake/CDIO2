namespace GymBookingSystem.Dtos
{
    public class StudentDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int ClassesBooked { get; set; }
        public int PtSessionsBooked { get; set; }
    }
}
