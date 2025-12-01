namespace OneSale.Application.DTOs;
public class OrderItemDto
{
    public Guid ProductId { get; init; }
    public required string ProductName { get; init; }
    public int Quantity { get; init; }
    public decimal DiscountedPrice { get; init; }
}
