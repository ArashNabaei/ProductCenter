
using Application.Services.Accounts;
using MediatR;

namespace Application.Features.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler <GetUserQuery>
    {

        private readonly IAccountService _accountService;

        public GetUserQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
