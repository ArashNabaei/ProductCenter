
using Application.Dtos;
using Application.Services.Products;
using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetProductsByUserIdQueryHandler : IRequestHandler<GetProductsByUserIdQuery, IEnumerable<ProductDto>>
    {

        private readonly IProductService _productService;

        public GetProductsByUserIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<IEnumerable<ProductDto>> Handle(GetProductsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProducts(request.UserId);

            return products;
        }
    }
}
