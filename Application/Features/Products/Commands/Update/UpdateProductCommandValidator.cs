
using FluentValidation;

namespace Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {

        public UpdateProductCommandValidator()
        {

            RuleFor(c => c.ProductDto.Name)
                .NotEmpty().WithMessage("Product name is required");

            RuleFor(c => c.ProductDto.Id)
                .NotEmpty().WithMessage("Product name is required")
                .GreaterThan(0).WithMessage("Product id must be greater than 0.");

            RuleFor(c => c.ProductId)
                .NotEmpty().WithMessage("Product id is required.")
                .GreaterThan(0).WithMessage("Product id must be greater than 0.")
                .Must((command, productId) => productId == command.ProductDto.Id)
                .WithMessage("The Ids should be equal.");

        }

    }
}
