using FluentValidation;

namespace eShopping.Catalog.Application.Products.Commands.Create
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Summary)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.ImageFile)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Price)
                .GreaterThan(0);
            RuleFor(x => x.Brands)
                .NotNull();
            RuleFor(x => x.Types)
                .NotNull();
        }
    }
}