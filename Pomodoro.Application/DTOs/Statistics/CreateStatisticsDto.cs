namespace Pomodoro.Application.DTOs.Statistics
{
    public class CreateStatisticsDto
    {
        public int TotalFocusTime { get; set; }
        public int SessionsCompleted { get; set; }
        public int GoalsAchieved { get; set; }
        public double FocusScore { get; set; }
    }
} 