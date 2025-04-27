using Pomodoro.Domain.Enums;

namespace Pomodoro.Domain.Entities
{
    public class PomodoroTask : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskProgress Progress { get; set; }
        public User User { get; set; } = null!;
    }
} 