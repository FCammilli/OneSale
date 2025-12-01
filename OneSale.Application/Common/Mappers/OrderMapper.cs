using OneSale.Application.DTOs;

namespace OneSale.Application.Common.Mappers;
public class OrderMapper
{
    public static OrderDto ToDto(Domain.Entities.Order order)
    {
        var itemsDto = order.Items.Select(item => new OrderItemDto
        {
            ProductId = item.Product.Id,
            ProductName = item.Product.Name,
            Quantity = item.Quantity.Value,
            DiscountedPrice = item.DiscountedPrice
        }).ToList();
        return new OrderDto(
            order.Id,
            order.User.Id,
            itemsDto,
            order.Total
        );
    }
}
