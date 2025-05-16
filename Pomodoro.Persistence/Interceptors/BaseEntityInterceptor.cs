using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pomodoro.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Pomodoro.Persistence.Interceptors
{
    public class BaseEntityInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public BaseEntityInterceptor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntity(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntity(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntity(DbContext? context)
        {
            if (context is null) return;

            foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                var username = _contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value ?? "undefined";

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = username;
                    entry.Entity.UpdatedBy = username;
                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedBy = username;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    if (entry.Entity is PomodoroTask || entry.Entity is User)
                    {
                        return;
                    }
                    

                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.UpdatedBy = username;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
} 