using Inc.MyFamily.Application.Interfaces.UseCases;
using Inc.MyFamily.Application.UseCase;
using Inc.MyFamily.Application.UseCase.Authenticate.Children;
using Inc.MyFamily.Application.UseCase.Authenticate.Parents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inc.MyFamily.IoC.UseCase
{
    public static class UseCaseInjections
    {
        public static IServiceCollection AddUseCase(this IServiceCollection services, IConfiguration configruation)
        {
            services.AddScoped<IAuthenticateChildrenUseCase, AuthenticateChildrenUseCase>();
            services.AddScoped<IAuthenticateParentUseCase, AuthenticateParentUseCase>();
            services.AddScoped<IGetAllChildrenByFamilyIdUseCase, GetAllChildrenByFamilyIdUseCase>();

            return services;
        }
    }
}
