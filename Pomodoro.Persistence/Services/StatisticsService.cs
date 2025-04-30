using Pomodoro.Application.DTOs.Statistics;
using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Application.Interfaces.Services;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Persistence.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<StatisticsDto?> GetByUserIdAsync(int userId)
        {
            var statistics = await _statisticsRepository.GetByUserIdAsync(userId);
            if (statistics == null)
                return null;

            return new StatisticsDto
            {
                Id = statistics.Id,
                UserId = statistics.UserId,
                TotalFocusTime = statistics.TotalFocusTime,
                SessionsCompleted = statistics.SessionsCompleted,
                GoalsAchieved = statistics.GoalsAchieved,
                FocusScore = statistics.FocusScore
            };
        }

        public async Task<bool> CreateAsync(CreateStatisticsDto dto, int userId)
        {
            // Check if statistics already exist for this user
            var existingStats = await _statisticsRepository.GetByUserIdAsync(userId);
            if (existingStats != null)
            {
                // Update existing statistics
                existingStats.TotalFocusTime = dto.TotalFocusTime;
                existingStats.SessionsCompleted = dto.SessionsCompleted;
                existingStats.GoalsAchieved = dto.GoalsAchieved;
                existingStats.FocusScore = dto.FocusScore;
                _statisticsRepository.Update(existingStats);
            }
            else
            {
                // Create new statistics
                var statistics = new Statistics
                {
                    UserId = userId,
                    TotalFocusTime = dto.TotalFocusTime,
                    SessionsCompleted = dto.SessionsCompleted,
                    GoalsAchieved = dto.GoalsAchieved,
                    FocusScore = dto.FocusScore
                };
                await _statisticsRepository.CreateAsync(statistics);
            }

            return await _statisticsRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(UpdateStatisticsDto dto)
        {
            var statistics = await _statisticsRepository.GetByIdAsync(dto.Id);
            if (statistics == null)
                return false;

            statistics.TotalFocusTime = dto.TotalFocusTime;
            statistics.SessionsCompleted = dto.SessionsCompleted;
            statistics.GoalsAchieved = dto.GoalsAchieved;
            statistics.FocusScore = dto.FocusScore;

            _statisticsRepository.Update(statistics);
            return await _statisticsRepository.SaveChangesAsync() > 0;
        }
    }
} 