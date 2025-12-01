
using MediatR;

namespace Application.Features.Products.Commands
{
    public record DeleteProductCommand(int UserId, int ProductId) : IRequest
    {
    }
}
