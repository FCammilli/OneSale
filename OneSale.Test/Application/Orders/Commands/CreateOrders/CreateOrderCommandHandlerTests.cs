using Moq;
using OneSale.Application;
using OneSale.Application.DTOs;
using OneSale.Application.Orders.Commands.CreateOrders;
using OneSale.Domain.Entities;
using OneSale.Domain.Repositories;

namespace OneSale.Test.Application.Orders.Commands.CreateOrders;
public class CreateOrderCommandHandlerTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IOrderRepository> _orderRepositoryMock;
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IDiscountService> _discountServiceMock;
    private readonly CreateOrderCommandHandler _handler;

    public CreateOrderCommandHandlerTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _userRepositoryMock = new Mock<IUserRepository>();
        _discountServiceMock = new Mock<IDiscountService>();

        _handler = new CreateOrderCommandHandler(
            _productRepositoryMock.Object,
            _orderRepositoryMock.Object,
            _userRepositoryMock.Object,
            _discountServiceMock.Object
        );
    }

    [Fact]
    public async Task Handle_ShouldCreateOrder_WhenValidRequest()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var user = new User(userId, "Test User", "test@example.com");
        var product = new Product(productId, "Test Product", 100m);
        var discount = 0.1m; // 10% discount
        var request = new CreateOrderCommand
        {
            UserId = userId,
            Items = new List<OrderItemRequestDto>
            {
                new OrderItemRequestDto { ProductId = productId, Quantity = 2 }
            }
        };

        _userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);
        _productRepositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(product);
        _discountServiceMock.Setup(service => service.GetProductDiscountAsync(productId)).ReturnsAsync(discount);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(userId, result.userId);
        Assert.Single(result.items);
        Assert.Equal(productId, result.items[0].ProductId);
        Assert.Equal(2, result.items[0].Quantity);
        Assert.Equal(90m, result.items[0].DiscountedPrice); // 100 - 10% = 90

        _orderRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Order>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenUserNotFound()
    {
        // Arrange
        var request = new CreateOrderCommand
        {
            UserId = Guid.NewGuid(),
            Items = new List<OrderItemRequestDto>()
        };

        _userRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((User?)null);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenProductNotFound()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User(userId, "Test User", "test@example.com");
        var request = new CreateOrderCommand
        {
            UserId = userId,
            Items = new List<OrderItemRequestDto>
            {
                new OrderItemRequestDto { ProductId = Guid.NewGuid(), Quantity = 1 }
            }
        };

        _userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);
        _productRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Product?)null);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
    }
}