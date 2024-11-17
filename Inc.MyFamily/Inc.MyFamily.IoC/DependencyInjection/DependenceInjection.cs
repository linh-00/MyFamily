using Inc.MyFamily.DAL.Context;
using Inc.MyFamily.IoC.Mappings;
using Inc.MyFamily.IoC.Repositories;
using Inc.MyFamily.IoC.Services;
using Inc.MyFamily.IoC.UseCase;
using Inc.MyFamily.IoC.Validator;
using Inc.MyFamily.Shared.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inc.MyFamily.IoC.DependencyInjection
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UserRequestInfo>();
            services.AddDbContext<dbMyFamilyContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyFamily")), ServiceLifetime.Transient);

            services.AddRepositories(configuration);
            services.AddServices(configuration);
            services.AddUseCase(configuration);
            services.AddValidator(configuration);

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
