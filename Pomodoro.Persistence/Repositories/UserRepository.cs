using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Pomodoro.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
} 