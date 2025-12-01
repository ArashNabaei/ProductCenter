
using Application.Services.Accounts;
using MediatR;

namespace Application.Features.Users.Queries
{
    public class GetUserByUsernameQueryHandler : IRequestHandler <GetUserByUsernameQuery>
    {

        private readonly IAccountService _accountService;

        public GetUserByUsernameQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
