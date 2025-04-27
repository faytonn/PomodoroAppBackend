using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Context;

namespace Pomodoro.Persistence.Repositories
{
    public class FocusSessionRepository : GenericRepository<FocusSession>, IFocusSessionRepository
    {
        public FocusSessionRepository(AppDbContext context) : base(context) { }
    }
} 