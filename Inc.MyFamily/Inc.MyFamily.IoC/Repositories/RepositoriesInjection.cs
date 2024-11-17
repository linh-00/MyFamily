using Inc.MyFamily.DAL.Repositories;
using Inc.MyFamily.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inc.MyFamily.IoC.Repositories
{
    public static class RepositoriesInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IChildRepository, ChildrenRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<IParentRepository, ParentsRepository>();

            return services;
        }
    }
}
