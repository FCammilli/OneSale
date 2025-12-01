using MediatR;
using OneSale.Application.Common.Mappers;
using OneSale.Application.DTOs;
using OneSale.Domain.Entities;
using OneSale.Domain.Repositories;
using OneSale.Domain.ValueObjects;

namespace OneSale.Application.Orders.Commands.CreateOrders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        private readonly IDiscountService _discountService;


        public CreateOrderCommandHandler(
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IUserRepository userRepository,
            IDiscountService discountService
            )
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _discountService = discountService;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var orderItems = new List<Item>();
            decimal totalAmount = 0;

            foreach (var item in request.Items)
            {

                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (product == null)
                {
                    throw new Exception("Product not found");
                }

                var discount = await _discountService.GetProductDiscountAsync(item.ProductId);

                var discountedAmount = product.Price * (1 - discount);

                var orderItem = new Item(product, Quantity.From(item.Quantity), discountedAmount);

                orderItems.Add(orderItem);

                totalAmount += discountedAmount * item.Quantity;
            }

            var order = new Order(Guid.NewGuid(), user, orderItems, totalAmount)
            {
                User = user
            };

            await _orderRepository.AddAsync(order);

            return OrderMapper.ToDto(order);
        }
    }
}
