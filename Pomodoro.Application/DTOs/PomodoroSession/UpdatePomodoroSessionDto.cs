using Pomodoro.Domain.Enums;

namespace Pomodoro.Application.DTOs.PomodoroSession
{
    public class UpdatePomodoroSessionDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public PomodoroSessionType Type { get; set; }
    }
} 