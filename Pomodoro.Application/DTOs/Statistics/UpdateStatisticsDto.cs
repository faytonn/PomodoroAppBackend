namespace Pomodoro.Application.DTOs.Statistics
{
    public class UpdateStatisticsDto
    {
        public int Id { get; set; }
        public int TotalFocusTime { get; set; }
        public int SessionsCompleted { get; set; }
        public int GoalsAchieved { get; set; }
        public double FocusScore { get; set; }
    }
} 