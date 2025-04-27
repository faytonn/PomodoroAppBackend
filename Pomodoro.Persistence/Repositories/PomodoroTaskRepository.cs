using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Context;

namespace Pomodoro.Persistence.Repositories
{
    public class PomodoroTaskRepository : GenericRepository<PomodoroTask>, IPomodoroTaskRepository
    {
        public PomodoroTaskRepository(AppDbContext context) : base(context) { }
    }
} 