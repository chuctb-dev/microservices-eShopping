using eShopping.Discount.Api.Data;
using eShopping.SharedKernel.Exceptions;
using eShopping.SharedKernel.MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShopping.Discount.Api.Features.Discounts.Commands.Delete
{
    public class DeleteDiscountHandler(DiscountDbContext dbContext) : ICommandHandler<DeleteDiscountCommand, bool>
    {
        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = await dbContext.Coupons.Where(c => c.ProductId == request.ProductId)
                .SingleOrDefaultAsync() ?? throw new NotFoundException("Coupon not found");

            dbContext.Coupons.Remove(coupon);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
