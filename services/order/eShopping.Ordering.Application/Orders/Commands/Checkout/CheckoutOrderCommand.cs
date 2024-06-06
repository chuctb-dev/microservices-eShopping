using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Ordering.Application.Orders.Commands.Checkout
{
    public record CheckoutOrderCommand(
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
        string CVV,
        int PaymentMethod) : ICommand<Result>;
}