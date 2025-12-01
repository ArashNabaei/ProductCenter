using Application.Services.Products;
using MediatR;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.CreateProduct(request.UserId, request.ProductName);
        }

    }
}
