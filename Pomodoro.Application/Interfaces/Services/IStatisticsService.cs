using Pomodoro.Application.DTOs.Statistics;

namespace Pomodoro.Application.Interfaces.Services
{
    public interface IStatisticsService
    {
        Task<StatisticsDto?> GetByUserIdAsync(int userId);
    }
} 