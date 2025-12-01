
using FluentValidation;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {

        public CreateProductCommandValidator()
        {
            RuleFor(c => c.UserId)
                .NotEmpty().WithMessage("UserId is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(c => c.ProductName)
                .NotEmpty().WithMessage("Product name is required.");
        }

    }
}
