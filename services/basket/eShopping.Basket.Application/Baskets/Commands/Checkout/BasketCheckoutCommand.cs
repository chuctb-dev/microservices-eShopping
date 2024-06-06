using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Basket.Application.Baskets.Commands.Checkout
{
    public record BasketCheckoutCommand(
        string UserName,
        decimal TotalPrice,
        string FirstName,
        string LastName,
        string EmailAddress,
        string AddressLine,
        string Country,
        string State,
        string ZipCode,
        string CardName,
        string CardNumber,
        string Expiration,
        string Cvv,
        int PaymentMethod) : ICommand<Result>;

}