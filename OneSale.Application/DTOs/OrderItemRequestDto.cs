namespace OneSale.Application.DTOs;

public record OrderItemRequestDto
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}
