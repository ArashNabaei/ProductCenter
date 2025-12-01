
using MediatR;

namespace Application.Features.Products.Commands
{
    public record CreateProductCommand(int UserId, string ProductName) : IRequest
    {
    }
}
