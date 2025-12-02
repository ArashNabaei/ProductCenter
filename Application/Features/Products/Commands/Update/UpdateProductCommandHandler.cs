using Application.Services.Products;
using FluentValidation;
using MediatR;

namespace Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {

        private readonly IProductService _productService;

        private readonly IValidator<UpdateProductCommand> _validator;

        public UpdateProductCommandHandler(IProductService productService, IValidator<UpdateProductCommand> validator)
        {
            _productService = productService;
            _validator = validator;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _productService.UpdateProduct(request.UserId, request.ProductId, request.ProductDto);
        }

    }
}
