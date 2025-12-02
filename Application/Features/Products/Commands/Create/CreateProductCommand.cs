using MediatR;

namespace Application.Features.Products.Commands.Create
{
    public record CreateProductCommand(int UserId, string ProductName) : IRequest
    {
    }
}
