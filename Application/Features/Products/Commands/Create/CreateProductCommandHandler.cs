using Application.Services.Products;
using FluentValidation;
using MediatR;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductService _productService;

        private readonly IValidator<CreateProductCommand> _validator;

        public CreateProductCommandHandler(IProductService productService, IValidator<CreateProductCommand> validator)
        {
            _productService = productService;
            _validator = validator;
        }

        //public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        //{
        //    var validationResult = await _validator.ValidateAsync(request);

        //    if (!validationResult.IsValid)
        //        throw new ValidationException(validationResult.Errors);

        //    await _productService.CreateProduct(request.UserId, request.ProductName);
        //}

        async Task<Unit> IRequestHandler<CreateProductCommand, Unit>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _productService.CreateProduct(request.UserId, request.ProductName);

            return Unit.Value;
        }
    }
}
