using MediatR;

namespace Application.Features.Products.Commands.Delete
{
    public record DeleteProductCommand(int UserId, int ProductId) : IRequest
    {
    }
}
