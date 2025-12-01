
using Application.Services.Accounts;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, string>
    {

        private readonly IAccountService _accountService;

        public SignInCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var userId = await _accountService.ValidateUser(request.Username, request.Password);

            var token =  _accountService.GenerateToken(userId);

            return token;
        }
    }
}
