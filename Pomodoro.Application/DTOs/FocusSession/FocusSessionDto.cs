namespace Pomodoro.Application.DTOs.FocusSession
{
    public class FocusSessionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public string? Goals { get; set; }
    }
} 