using eShopping.Discount.Api.Data;
using eShopping.Discount.Api.Mappers;
using eShopping.Discount.Grpc.Protos;
using eShopping.SharedKernel.Exceptions;
using eShopping.SharedKernel.MediatR;
using Microsoft.EntityFrameworkCore;
using CouponEntity = eShopping.Discount.Api.Domain.CouponAggregate.Coupon;

namespace eShopping.Discount.Api.Features.Discounts.Commands.Create
{
    public class CreateDiscountHandler(DiscountDbContext dbContext) : ICommandHandler<CreateDiscountCommand, CouponModel>
    {
        public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var ifExists = await dbContext.Coupons.AnyAsync(c => c.ProductId == request.ProductId);
            if (ifExists) throw new ConflictException("This product already have a discount");

            var coupon = DiscountMapper.Mapper.Map<CouponEntity>(request);
            await dbContext.Coupons.AddAsync(coupon);
            await dbContext.SaveChangesAsync();
            var couponModel = DiscountMapper.Mapper.Map<CouponModel>(coupon);
            return couponModel;
        }
    }
}
