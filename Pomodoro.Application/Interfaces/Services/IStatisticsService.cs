using Pomodoro.Application.DTOs.Statistics;

namespace Pomodoro.Application.Interfaces.Services
{
    public interface IStatisticsService
    {
        Task<StatisticsDto?> GetByUserIdAsync(int userId);
        Task<bool> CreateAsync(CreateStatisticsDto dto, int userId);
        Task<bool> UpdateAsync(UpdateStatisticsDto dto);
    }
} 