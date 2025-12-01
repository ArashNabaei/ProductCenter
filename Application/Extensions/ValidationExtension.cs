
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
            services.AddTransient<IValidator<SignInCommand>,  SignInCommandValidator>();

            return services;
        }

    }
}
