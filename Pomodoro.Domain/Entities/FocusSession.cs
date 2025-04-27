namespace Pomodoro.Domain.Entities
{
    public class FocusSession : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public string? Goals { get; set; }
        public User User { get; set; } = null!;
    }
} 