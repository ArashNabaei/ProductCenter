
using MediatR;

namespace Application.Features.Users.Commands
{
    public record SignUpCommand (string Username, string Password) : IRequest
    {
    }
}
