using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomodoro.Persistence.Context;

namespace Pomodoro.Persistence.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=PomodoroDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;");

            return new AppDbContext(optionsBuilder.Options, null!);
        }
    }
} 