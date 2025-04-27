namespace Pomodoro.Application.DTOs.BlockedSiteDTO
{
    public class CreateBlockedSiteDto
    {
        public int UserId { get; set; }
        public string SiteUrl { get; set; } = null!;
    }
} 