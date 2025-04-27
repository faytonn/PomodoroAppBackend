namespace Pomodoro.Application.DTOs.BlockedSite
{
    public class BlockedSiteDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SiteUrl { get; set; } = null!;
    }
} 