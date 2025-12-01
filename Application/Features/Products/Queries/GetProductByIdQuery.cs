
using Application.Dtos;
using MediatR;

namespace Application.Features.Products.Queries
{
    public record GetProductByIdQuery(int UserId, int ProductId) : IRequest<ProductDto>
    {
    }
}
