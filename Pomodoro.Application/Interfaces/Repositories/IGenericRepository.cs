using System.Linq.Expressions;

namespace Pomodoro.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null);
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
        Task<int> SaveChangesAsync();
    }
} 