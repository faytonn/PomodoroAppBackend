using Pomodoro.Domain.Entities;

namespace Pomodoro.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ICollection<PomodoroTask> PomodoroTasks { get; set; } = new List<PomodoroTask>();
        public ICollection<PomodoroSession> PomodoroSessions { get; set; } = new List<PomodoroSession>();
        public ICollection<FocusSession> FocusSessions { get; set; } = new List<FocusSession>();
        public ICollection<BlockedSite> BlockedSites { get; set; } = new List<BlockedSite>();
        public Statistics? Statistics { get; set; }
    }
} 