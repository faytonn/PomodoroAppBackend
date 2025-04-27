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


            return services;
        }
    }
} 