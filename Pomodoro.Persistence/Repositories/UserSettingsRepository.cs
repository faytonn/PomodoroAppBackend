using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Pomodoro.Persistence.Repositories
{
    public class UserSettingsRepository : GenericRepository<UserSettings>, IUserSettingsRepository
    {
        public UserSettingsRepository(AppDbContext context) : base(context) { }

        public async Task<UserSettings?> GetByUserIdAsync(int userId)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.UserId == userId);
        }
    }
} 