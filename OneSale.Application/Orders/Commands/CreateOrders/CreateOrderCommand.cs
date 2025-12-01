using MediatR;
using OneSale.Application.DTOs;

namespace OneSale.Application.Orders.Commands.CreateOrders;

public class CreateOrderCommand : IRequest<OrderDto>
{
    public Guid UserId { get; set; }
    public required List<OrderItemRequestDto> Items { get; set; }
}
