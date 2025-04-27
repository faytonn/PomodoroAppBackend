namespace Pomodoro.Application.DTOs.StatisticsDTO
{
    public class StatisticsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TotalFocusTime { get; set; }
        public int SessionsCompleted { get; set; }
        public int GoalsAchieved { get; set; }
        public double FocusScore { get; set; }
    }
} 