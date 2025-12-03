
using Application.Dtos;
using MediatR;

namespace Application.Features.Products.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<ProductDto>>
    {
    }
}
