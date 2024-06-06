using FluentValidation;

namespace eShopping.Catalog.Application.Products.Commands.Update
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
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