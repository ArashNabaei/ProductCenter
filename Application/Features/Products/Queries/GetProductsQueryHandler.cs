
using Application.Dtos;
using Application.Services.Products;
using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductService _productService;

        public GetProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProducts();

            return products;
        }
    }
}
