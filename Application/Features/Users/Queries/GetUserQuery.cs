
using MediatR;

namespace Application.Features.Users.Queries
{
    public record GetUserQuery(string Username, string Password) : IRequest
    {

    }

}
