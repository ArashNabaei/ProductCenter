
using Application.Dtos;
using Application.Services.Accounts;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand>
    {

        private readonly IAccountService _accountService;

        public SignUpCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var accountDto = new AccountDto
            {
                Username = request.Username,
                Password = request.Password,
            };

            await _accountService.CreateUser(accountDto);
        }
    }
}
