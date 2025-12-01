
using Application.Features.Users.Commands;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ValidationExtension
    {

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SignUpCommand>, SignUpCommandValidator>();

            return services;
        }

    }
}
