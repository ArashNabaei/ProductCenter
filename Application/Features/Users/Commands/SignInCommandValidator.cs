
using FluentValidation;

namespace Application.Features.Users.Commands
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {

        public SignInCommandValidator()
        {
            RuleFor(c => c.Username)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Password is required.");
        }

    }
}
