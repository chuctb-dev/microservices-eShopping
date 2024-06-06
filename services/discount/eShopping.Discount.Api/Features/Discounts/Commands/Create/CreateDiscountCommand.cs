using eShopping.Discount.Grpc.Protos;
using eShopping.SharedKernel.MediatR;

namespace eShopping.Discount.Api.Features.Discounts.Commands.Create
{
    public record CreateDiscountCommand(string ProductId, string ProductName, string Description, decimal Amount) : ICommand<CouponModel>;
}
