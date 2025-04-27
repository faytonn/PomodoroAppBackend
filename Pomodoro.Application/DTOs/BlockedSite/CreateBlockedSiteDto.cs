namespace Pomodoro.Application.DTOs.BlockedSite
{
    public class CreateBlockedSiteDto
    {
        public int UserId { get; set; }
        public string SiteUrl { get; set; } = null!;
    }
} 