
using MediatR;

namespace Application.Features.Users.Queries
{
    public record GetUserByUsernameQuery(string Username) : IRequest
    {

    }

}
