using Inc.MyFamily.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inc.MyFamily.IoC.Services
{
    public static class ServicesInjections
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthTokenService, IAuthTokenService>();

            return services;
        }
    }
}
