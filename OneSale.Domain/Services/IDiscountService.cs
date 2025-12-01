namespace OneSale.Application;

public interface IDiscountService
{
    Task<decimal> GetProductDiscountAsync(Guid productId);
}
