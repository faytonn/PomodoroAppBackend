namespace Pomodoro.Domain.Entities
{
    public class UserSettings : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public string AccentColor { get; set; } = "#ff6b6b"; 
        public int FontSize { get; set; } = 16; 
        public bool EnableNotifications { get; set; } = true;
        public bool EnableSound { get; set; } = true;
        public int WorkDuration { get; set; } = 25; 
        public int ShortBreakDuration { get; set; } = 5; 
        public int LongBreakDuration { get; set; } = 15; 
        public int LongBreakInterval { get; set; } = 4; 
        public User User { get; set; } = null!;
    }
} 