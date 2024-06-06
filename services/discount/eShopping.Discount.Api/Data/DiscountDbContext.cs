using eShopping.Discount.Api.Domain.CouponAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace eShopping.Discount.Api.Data
{
    public class DiscountDbContext(DbContextOptions<DiscountDbContext> options) : DbContext(options)
    {
        public DbSet<Coupon> Coupons => Set<Coupon>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
