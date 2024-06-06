using eShopping.Discount.Grpc.Protos;
using eShopping.SharedKernel.MediatR;

namespace eShopping.Discount.Api.Features.Discounts.Commands.Update
{
    public record UpdateDiscountCommand(string ProductId, string ProductName, string Description, decimal Amount) : ICommand<CouponModel>;
}
