using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pomodoro.Application.ServiceRegistrations
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddFluentValidationAutoValidation();
            //services.AddValidatorsFromAssemblyContaining(typeof(SettingUpdateDtoValidator));

            return services;
        }
    }
}
