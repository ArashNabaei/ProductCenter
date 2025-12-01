
using Application.Dtos;
using Application.Services.Accounts;
using MediatR;

namespace Application.Features.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler <GetUserQuery, AccountDto>
    {

        private readonly IAccountService _accountService;

        public GetUserQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<AccountDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetUserByUsernameAndPassword(request.Username, request.Password);

            return user;
        }
    }
}
