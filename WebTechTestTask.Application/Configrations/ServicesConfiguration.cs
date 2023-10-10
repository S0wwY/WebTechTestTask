using Microsoft.Extensions.DependencyInjection;
using WebTechTestTask.Application.Interfaces;
using WebTechTestTask.Application.Services;

namespace WebTechTestTask.Application.Configrations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
