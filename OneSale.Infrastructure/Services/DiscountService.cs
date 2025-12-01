namespace OneSale.Application
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;
        private readonly string _discountApiUrl;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _discountApiUrl = "https://mockable.io/api/discounts"; // Mock API URL
        }

        public async Task<decimal> GetProductDiscountAsync(Guid productId)
        {
            // Mock implementation for demonstration
            return productId == Guid.Parse("1a4cd040-8a7a-4c9a-8d7e-72eef3adb0cb") ? 0.15m : 0.0m; // 15% discount for specific product
        }
    }
}
