using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Context;

namespace Pomodoro.Persistence.Repositories
{
    public class BlockedSiteRepository : GenericRepository<BlockedSite>, IBlockedSiteRepository
    {
        public BlockedSiteRepository(AppDbContext context) : base(context) { }
    }
} 