namespace GymBookingSystem.Dtos
{
    public class TrainerPtSessionDto
    {
        public int SessionId { get; set; }
        public DateOnly SessionDate { get; set; } 
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string ClientEmail { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
