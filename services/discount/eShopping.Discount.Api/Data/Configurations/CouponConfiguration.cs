using eShopping.Discount.Api.Domain.CouponAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopping.Discount.Api.Data.Configurations
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(t => t.ProductId)
                .IsRequired();

            builder.Property(t => t.ProductName)
                .IsRequired();

            builder.Property(t => t.Amount)
                .IsRequired();

            builder.HasIndex(t => t.ProductId);
            builder.HasIndex(t => t.ProductName);
        }
    }
}
