using eShopping.Discount.Api.Data;
using eShopping.Discount.Api.Mappers;
using eShopping.Discount.Grpc.Protos;
using eShopping.SharedKernel.MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShopping.Discount.Api.Features.Discounts.Queries.Get
{
    public class GetDiscountHandler(DiscountDbContext dbContext) : IQueryHandler<GetDiscountQuery, CouponModel>
    {
        public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupon = await dbContext.Coupons.AsNoTracking()
                .Where(c => c.ProductId == request.ProductId)
                .FirstOrDefaultAsync();

            return DiscountMapper.Mapper.Map<CouponModel>(coupon);
        }
    }
}
