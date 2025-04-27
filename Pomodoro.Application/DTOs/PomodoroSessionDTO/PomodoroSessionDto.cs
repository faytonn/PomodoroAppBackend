using Pomodoro.Domain.Enums;

namespace Pomodoro.Application.DTOs.PomodoroSessionDTO
{
    public class PomodoroSessionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public PomodoroSessionType Type { get; set; }
    }
} 