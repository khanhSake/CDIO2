namespace GymBookingSystem.Dtos
{
    public class TrainerClassScheduleDto
    {
        public int ScheduleId { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public int DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }   
        public TimeOnly EndTime { get; set; }
        public int AvailableSpots { get; set; }
    }
}
