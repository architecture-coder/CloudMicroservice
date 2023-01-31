using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtosService.DiscountProtosServiceClient _discountProtosService;

        public DiscountGrpcService (DiscountProtosService.DiscountProtosServiceClient discountProtosService)
        {
            _discountProtosService = discountProtosService ?? throw new ArgumentNullException(nameof(discountProtosService));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };

            return await _discountProtosService.GetDiscountAsync(discountRequest);
        }
    }
}
