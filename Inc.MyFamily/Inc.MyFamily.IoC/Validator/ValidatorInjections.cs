using FluentValidation;
using Inc.MyFamily.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inc.MyFamily.IoC.Validator
{
    public static class ValidatorInjections
    {
        public static IServiceCollection AddValidator(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IValidator<AuthenticateRequest>>();

            return services;
        }
    }
}
