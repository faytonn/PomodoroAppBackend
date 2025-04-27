namespace Pomodoro.Domain.Entities
{
    public class BlockedSite : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public string SiteUrl { get; set; } = null!;
        public User User { get; set; } = null!;
    }
} 