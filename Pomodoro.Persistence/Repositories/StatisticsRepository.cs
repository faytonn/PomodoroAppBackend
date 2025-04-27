using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Context;

namespace Pomodoro.Persistence.Repositories
{
    public class StatisticsRepository : GenericRepository<Statistics>, IStatisticsRepository
    {
        public StatisticsRepository(AppDbContext context) : base(context) { }
    }
} 