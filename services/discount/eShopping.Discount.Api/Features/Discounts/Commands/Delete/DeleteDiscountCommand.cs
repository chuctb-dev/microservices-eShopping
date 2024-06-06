using eShopping.SharedKernel.MediatR;

namespace eShopping.Discount.Api.Features.Discounts.Commands.Delete
{
    public record DeleteDiscountCommand(string ProductId) : ICommand<bool>;
}
