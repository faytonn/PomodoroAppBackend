using Pomodoro.Domain.Entities;

namespace Pomodoro.Application.Interfaces.Repositories
{
    public interface IStatisticsRepository : IGenericRepository<Statistics>
    {
        Task<Statistics?> GetByUserIdAsync(int userId);
    }
} 