namespace OneSale.Application.DTOs;
public record OrderDto(Guid id,
                       Guid userId,
                       List<OrderItemDto> items,
                       decimal total);
