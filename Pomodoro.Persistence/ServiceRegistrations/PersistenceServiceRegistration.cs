using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Application.Interfaces.Services;
using Pomodoro.Persistence.Repositories;
using Pomodoro.Persistence.Services;
using Pomodoro.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Persistence.Interceptors;

namespace Pomodoro.Persistence.ServiceRegistrations
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<BaseEntityInterceptor>();

            services.AddScoped<IPomodoroTaskRepository, PomodoroTaskRepository>();
            services.AddScoped<IPomodoroTaskService, PomodoroTaskService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPomodoroSessionRepository, PomodoroSessionRepository>();
            services.AddScoped<IPomodoroSessionService, PomodoroSessionService>();

            services.AddScoped<IFocusSessionRepository, FocusSessionRepository>();
            services.AddScoped<IFocusSessionService, FocusSessionService>();

            services.AddScoped<IBlockedSiteRepository, BlockedSiteRepository>();
            services.AddScoped<IBlockedSiteService, BlockedSiteService>();

            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<IStatisticsService, StatisticsService>();

            services.AddScoped<IUserSettingsRepository, UserSettingsRepository>();
            services.AddScoped<IUserSettingsService, UserSettingsService>();

            return services;
        }
    }
} 