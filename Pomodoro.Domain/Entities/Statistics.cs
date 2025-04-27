namespace Pomodoro.Domain.Entities
{
    public class Statistics : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public int TotalFocusTime { get; set; }
        public int SessionsCompleted { get; set; }
        public int GoalsAchieved { get; set; }
        public double FocusScore { get; set; }
        public User User { get; set; } = null!;
    }
} 