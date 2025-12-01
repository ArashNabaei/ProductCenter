
using Application.Dtos;
using MediatR;

namespace Application.Features.Products.Commands
{
    public record UpdateProductCommand(int UserId, int ProductId, ProductDto ProductDto) : IRequest
    {
    }
}
