
using FluentValidation;

namespace Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {

        public UpdateProductCommandValidator()
        {

            RuleFor(c => c.ProductId)
                .NotEmpty().WithMessage("Product id is required.")
                .GreaterThan(0).WithMessage("Product is must be greater than 0.");

            RuleFor(c => c.ProductDto.Name)
                .NotEmpty().WithMessage("Product name is required");

        }

    }
}
