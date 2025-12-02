using Application.Services.Products;
using FluentValidation;
using MediatR;

namespace Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {

        private readonly IProductService _productService;

        private readonly IValidator<DeleteProductCommand> _validator;

        public DeleteProductCommandHandler(IProductService productService, IValidator<DeleteProductCommand> validator)
        {
            _productService = productService;
            _validator = validator;
        }

        //public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        //{
        //    var validationResult = await _validator.ValidateAsync(request);

        //    if (!validationResult.IsValid)
        //        throw new ValidationException(validationResult.Errors);

        //    await _productService.DeleteProduct(request.UserId, request.ProductId);
        //}

        async Task<Unit> IRequestHandler<DeleteProductCommand, Unit>.Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _productService.DeleteProduct(request.UserId, request.ProductId);

            return Unit.Value;
        }
    }
}
