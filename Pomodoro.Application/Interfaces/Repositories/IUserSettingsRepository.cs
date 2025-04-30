using Pomodoro.Domain.Entities;

namespace Pomodoro.Application.Interfaces.Repositories
{
    public interface IUserSettingsRepository : IGenericRepository<UserSettings>
    {
        Task<UserSettings?> GetByUserIdAsync(int userId);
    }
} 