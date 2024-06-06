using FluentValidation;

namespace eShopping.Basket.Application.Baskets.Commands.Create
{
    public class CreateShoppingCartValidator : AbstractValidator<CreateShoppingCartCommand>
    {
        public CreateShoppingCartValidator()
        {
            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Items)
                .NotEmpty()
                .Must(items => items != null && items.Count > 0).WithMessage("Items must contain at least one item")
                .ForEach(item =>
                {
                    item.SetValidator(new ShoppingCartItemDtoValidator());
                });
        }
    }

    public class ShoppingCartItemDtoValidator : AbstractValidator<ShoppingCartItemDto>
    {
        public ShoppingCartItemDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.ProductName)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Price)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.ImageFile)
                .NotNull()
                .NotEmpty();
        }
    }
}