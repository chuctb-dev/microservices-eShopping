using FluentValidation;

namespace eShopping.Discount.Api.Features.Discounts.Commands.Create
{
    public class CreateDiscountValidator : AbstractValidator<CreateDiscountCommand>
    {
        public CreateDiscountValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Amount)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
