using Pomodoro.Domain.Entities;

namespace Pomodoro.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<PomodoroTask> PomodoroTasks { get; set; } = new List<PomodoroTask>();
        public ICollection<PomodoroSession> PomodoroSessions { get; set; } = new List<PomodoroSession>();
        public ICollection<FocusSession> FocusSessions { get; set; } = new List<FocusSession>();
        public ICollection<BlockedSite> BlockedSites { get; set; } = new List<BlockedSite>();
        public Statistics? Statistics { get; set; }
    }
} 