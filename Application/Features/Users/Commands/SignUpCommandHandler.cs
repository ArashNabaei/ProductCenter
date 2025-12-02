
using Application.Dtos;
using Application.Services.Accounts;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand>
    {

        private readonly IAccountService _accountService;

        private readonly IValidator<SignUpCommand> _validator;

        public SignUpCommandHandler(IAccountService accountService, IValidator<SignUpCommand> validator)
        {
            _accountService = accountService;
            _validator = validator;
        }

        public async Task<Unit> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var accountDto = new AccountDto
            {
                Username = request.Username,
                Password = request.Password,
            };

            await _accountService.CreateUser(accountDto);

            return Unit.Value;
        }

    }
}
