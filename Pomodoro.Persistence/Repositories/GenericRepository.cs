using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Pomodoro.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate) =>
            await _dbSet.FirstOrDefaultAsync(predicate);

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null) =>
            predicate == null ? _dbSet : _dbSet.Where(predicate);

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate) =>
            await _dbSet.AnyAsync(predicate);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
} 