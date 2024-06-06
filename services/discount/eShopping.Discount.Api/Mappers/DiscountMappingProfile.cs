using AutoMapper;
using eShopping.Discount.Api.Domain.CouponAggregate;
using eShopping.Discount.Api.Features.Discounts.Commands.Create;
using eShopping.Discount.Api.Features.Discounts.Commands.Update;
using eShopping.Discount.Grpc.Protos;

namespace eShopping.Discount.Api.Mappers
{
    public class DiscountMappingProfile : Profile
    {
        public DiscountMappingProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
            CreateMap<Coupon, CreateDiscountCommand>().ReverseMap();
            CreateMap<Coupon, UpdateDiscountCommand>().ReverseMap();
        }
    }
}
