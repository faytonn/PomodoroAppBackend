using Pomodoro.Domain.Enums;

namespace Pomodoro.Domain.Entities
{
    public class PomodoroSession : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public PomodoroSessionType Type { get; set; }
        public User User { get; set; } = null!;
    }
} 