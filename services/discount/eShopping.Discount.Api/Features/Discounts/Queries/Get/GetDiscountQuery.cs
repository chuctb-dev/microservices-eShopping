using eShopping.Discount.Grpc.Protos;
using eShopping.SharedKernel.MediatR;

namespace eShopping.Discount.Api.Features.Discounts.Queries.Get
{
    public record GetDiscountQuery(string ProductId) : IQuery<CouponModel>;
}
