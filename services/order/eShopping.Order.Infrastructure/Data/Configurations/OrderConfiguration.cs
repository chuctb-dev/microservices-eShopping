using eShopping.Ordering.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopping.Discount.Api.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(t => t.Username)
                .IsRequired();
            builder.Property(t => t.FirstName)
                .IsRequired();
            builder.Property(t => t.LastName)
                .IsRequired();

            builder.Property(t => t.EmailAddress)
                .IsRequired();
            builder.Property(t => t.AddressLine)
                .IsRequired();
            builder.Property(t => t.Country)
                .IsRequired();
            builder.Property(t => t.State)
                .IsRequired();
            builder.Property(t => t.ZipCode)
                .IsRequired();

            builder.Property(t => t.TotalPrice)
                .IsRequired();

            builder.Property(t => t.CardName)
                .IsRequired();
            builder.Property(t => t.CardNumber)
                .IsRequired();
            builder.Property(t => t.Expiration)
                .IsRequired();
            builder.Property(t => t.Cvv)
                .IsRequired();
            builder.Property(t => t.PaymentMethod)
                .IsRequired();
        }
    }
}
