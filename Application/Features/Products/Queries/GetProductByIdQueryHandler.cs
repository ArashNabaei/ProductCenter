
using Application.Dtos;
using Application.Services.Products;
using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {

        private readonly IProductService _productService;

        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productDto = await _productService.GetProductById(request.UserId, request.ProductId);

            return productDto;
        }
    }
}
