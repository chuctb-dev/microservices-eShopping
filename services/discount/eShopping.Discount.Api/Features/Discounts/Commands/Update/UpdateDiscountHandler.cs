using eShopping.Discount.Api.Data;
using eShopping.Discount.Api.Mappers;
using eShopping.Discount.Grpc.Protos;
using eShopping.SharedKernel.Exceptions;
using eShopping.SharedKernel.MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShopping.Discount.Api.Features.Discounts.Commands.Update
{
    public class UpdateDiscountHandler(DiscountDbContext dbContext) : ICommandHandler<UpdateDiscountCommand, CouponModel>
    {
        public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = await dbContext.Coupons.Where(c => c.ProductId == request.ProductId)
                .SingleOrDefaultAsync()
                ?? throw new NotFoundException("Coupon not found");

            coupon.ProductName = request.ProductName;
            coupon.Description = request.Description;
            coupon.Amount = request.Amount;

            dbContext.Update(coupon);
            await dbContext.SaveChangesAsync();
            return DiscountMapper.Mapper.Map<CouponModel>(coupon);
        }
    }
}
