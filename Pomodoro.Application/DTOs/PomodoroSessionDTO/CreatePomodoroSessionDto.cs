using Pomodoro.Domain.Enums;

namespace Pomodoro.Application.DTOs.PomodoroSessionDTO
{
    public class CreatePomodoroSessionDto
    {
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public PomodoroSessionType Type { get; set; }
    }
} 