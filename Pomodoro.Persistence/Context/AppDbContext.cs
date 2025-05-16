using Microsoft.EntityFrameworkCore;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Interceptors;
using System.Reflection;

namespace Pomodoro.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        private readonly BaseEntityInterceptor _entityInterceptor;

        public AppDbContext(DbContextOptions<AppDbContext> options, BaseEntityInterceptor entityInterceptor) : base(options)
        {
            _entityInterceptor = entityInterceptor;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PomodoroTask> PomodoroTasks { get; set; }
        public DbSet<PomodoroSession> PomodoroSessions { get; set; }
        public DbSet<FocusSession> FocusSessions { get; set; }
        public DbSet<BlockedSite> BlockedSites { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<PomodoroTask>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<PomodoroSession>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<FocusSession>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<BlockedSite>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Statistics>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<UserSettings>().HasQueryFilter(x => !x.IsDeleted);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_entityInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
} 