using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Context;

namespace Pomodoro.Persistence.Repositories
{
    public class PomodoroSessionRepository : GenericRepository<PomodoroSession>, IPomodoroSessionRepository
    {
        public PomodoroSessionRepository(AppDbContext context) : base(context) { }
    }
} 