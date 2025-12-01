
using FluentValidation;

namespace Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {

        public DeleteProductCommandValidator()
        {
            RuleFor(c => c.UserId)
                .NotEmpty().WithMessage("User id is required.")
                .GreaterThan(0).WithMessage("User id must be greater than 0.");

            RuleFor(c => c.ProductId)
                .NotEmpty().WithMessage("Product id is required.")
                .GreaterThan(0).WithMessage("Product id must be greater than 0.");
        }

    }
}
