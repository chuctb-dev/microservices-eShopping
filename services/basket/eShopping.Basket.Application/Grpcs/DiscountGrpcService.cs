using eShopping.Discount.Grpc.Protos;

namespace eShopping.Basket.Application.Grpcs
{
    public class DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
    {
        public async Task<CouponModel> GetDiscount(string productId)
            => await discountProtoServiceClient.GetDiscountAsync(new GetDiscountRequest { ProductId = productId });
    }
}
