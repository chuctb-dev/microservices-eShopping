using eShopping.SharedKernel.Entities;

namespace eShopping.Discount.Api.Domain.CouponAggregate
{
    public class Coupon : EntityBase<Guid>
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
