namespace Pomodoro.Application.DTOs.UserSettings
{
    public class UpdateUserSettingsDto
    {
        public int Id { get; set; }
        public string AccentColor { get; set; } = null!;
        public int? FontSize { get; set; }
        public bool? EnableNotifications { get; set; }
        public bool? EnableSound { get; set; }
        public int? WorkDuration { get; set; }
        public int? ShortBreakDuration { get; set; }
        public int? LongBreakDuration { get; set; }
        public int? LongBreakInterval { get; set; }
        public string Theme { get; set; } = null!;
    }
} 