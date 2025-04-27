namespace Pomodoro.Application.DTOs.FocusSession
{
    public class UpdateFocusSessionDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public string? Goals { get; set; }
    }
} 