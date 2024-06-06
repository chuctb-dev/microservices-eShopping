using FluentValidation;

namespace eShopping.Discount.Api.Features.Discounts.Commands.Update
{
    public class UpdateDiscountValidator : AbstractValidator<UpdateDiscountCommand>
    {
        public UpdateDiscountValidator()
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
