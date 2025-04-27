namespace Pomodoro.Application.DTOs.FocusSessionDTO
{
    public class CreateFocusSessionDto
    {
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public string? Goals { get; set; }
    }
} 