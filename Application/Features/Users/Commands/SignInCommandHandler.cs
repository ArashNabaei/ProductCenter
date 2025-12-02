
using Application.Services.Accounts;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, string>
    {

        private readonly IAccountService _accountService;

        private readonly IValidator<SignInCommand> _validator;

        public SignInCommandHandler(IAccountService accountService, IValidator<SignInCommand> validator)
        {
            _accountService = accountService;
            _validator = validator;
        }

        public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var userId = await _accountService.ValidateUser(request.Username, request.Password);

            var token =  _accountService.GenerateToken(userId);

            return token;
        }
    }
}
