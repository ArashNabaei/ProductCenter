
using MediatR;

namespace Application.Features.Users.Commands
{
    public record SignInCommand(string Username, string Password) : IRequest<string>
    {
    }
}
