
using Application.Dtos;
using MediatR;

namespace Application.Features.Products.Queries
{
    public record GetProductsByUserIdQuery(int UserId) : IRequest<List<ProductDto>>
    {
    }
}
