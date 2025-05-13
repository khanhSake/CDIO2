namespace GymBookingSystem.Dtos
{
    public class StudentProgressDto
    {
        public string ClassName { get; set; } = string.Empty;
        public DateTime? BookingDate { get; set; }   
        public string Status { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
