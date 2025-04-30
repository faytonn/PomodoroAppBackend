using Microsoft.EntityFrameworkCore;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Interceptors;

namespace Pomodoro.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        private readonly BaseEntityInterceptor _entityInterceptor;

        public AppDbContext(DbContextOptions<AppDbContext> options, BaseEntityInterceptor entityInterceptor)
            : base(options)
        {
            _entityInterceptor = entityInterceptor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_entityInterceptor);
            base.OnConfiguring(optionsBuilder);
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
        }
    }
} 