using Pomodoro.Domain.Entities;

namespace Pomodoro.Application.Interfaces.Repositories
{
    public interface IPomodoroTaskRepository : IGenericRepository<PomodoroTask>
    {
        // Add PomodoroTask-specific methods if needed
    }
} 