using eShopping.Discount.Api.Features.Discounts.Commands.Create;
using eShopping.Discount.Api.Features.Discounts.Commands.Delete;
using eShopping.Discount.Api.Features.Discounts.Commands.Update;
using eShopping.Discount.Api.Features.Discounts.Queries.Get;
using eShopping.Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace eShopping.Discount.Api.Grpcs.Discounts
{
    public class DiscountService(ILogger<DiscountService> logger, IMediator mediator) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var query = new GetDiscountQuery(request.ProductId);
            var result = await mediator.Send(query) ?? new CouponModel();
            logger.LogInformation($"Discount is retrieved for the Product Name: {request.ProductId} and Amount : {result.Amount}");
            return result;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var cmd = new CreateDiscountCommand(request.Coupon.ProductId, request.Coupon.ProductName, request.Coupon.Description, request.Coupon.Amount);
            var result = await mediator.Send(cmd) ?? new CouponModel();
            logger.LogInformation($"Discount is retrieved for the Product Name: {request.Coupon.ProductId} and Amount : {result.Amount}");
            return result;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var cmd = new UpdateDiscountCommand(request.Coupon.ProductId, request.Coupon.ProductName, request.Coupon.Description, request.Coupon.Amount);
            var result = await mediator.Send(cmd) ?? new CouponModel();
            logger.LogInformation($"Discount is retrieved for the Product Name: {request.Coupon.ProductId} and Amount : {result.Amount}");
            return result;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var cmd = new DeleteDiscountCommand(request.ProductId);
            var deleted = await mediator.Send(cmd);
            var response = new DeleteDiscountResponse
            {
                Success = deleted
            };
            return response;
        }
    }
}
