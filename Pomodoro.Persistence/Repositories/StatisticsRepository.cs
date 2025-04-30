using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Pomodoro.Persistence.Repositories
{
    public class StatisticsRepository : GenericRepository<Statistics>, IStatisticsRepository
    {
        public StatisticsRepository(AppDbContext context) : base(context) { }

        public async Task<Statistics?> GetByUserIdAsync(int userId)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.UserId == userId);
        }
    }
} 