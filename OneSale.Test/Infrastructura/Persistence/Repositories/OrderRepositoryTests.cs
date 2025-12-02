using Microsoft.EntityFrameworkCore;
using OneSale.Domain.Entities;
using OneSale.Domain.ValueObjects;
using OneSale.Infrastructure.Persistence;
using OneSale.Infrastructure.Persistence.Repositories;

namespace OneSale.Tests.Infrastructure.Persistence.Repositories;

public class OrderRepositoryTests
{
    private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

    public OrderRepositoryTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsOrder_WhenOrderExists()
    {
        using var context = new ApplicationDbContext(_dbContextOptions);
        var repository = new OrderRepository(context);

        var user = new User(Guid.NewGuid(), "Test User", "test@example.com");
        var product = new Product(Guid.NewGuid(), "Test Product", 100m);
        var item = new Item(product, Quantity.From(1), 90m);
        var order = new Order(Guid.NewGuid(), user, new List<Item> { item }, 90m);

        context.Orders.Add(order);
        await context.SaveChangesAsync();

        var result = await repository.GetByIdAsync(order.Id);

        Assert.NotNull(result);
        Assert.Equal(order.Id, result.Id);
    }

    [Fact]
    public async Task AddAsync_AddsOrderToDatabase()
    {
        using var context = new ApplicationDbContext(_dbContextOptions);
        var repository = new OrderRepository(context);

        var user = new User(Guid.NewGuid(), "Test User", "test@example.com");
        var product = new Product(Guid.NewGuid(), "Test Product", 100m);
        var item = new Item(product, Quantity.From(1), 90m);
        var order = new Order(Guid.NewGuid(), user, new List<Item> { item }, 90m);

        await repository.AddAsync(order);

        var result = await context.Orders.FindAsync(order.Id);

        Assert.NotNull(result);
        Assert.Equal(order.Id, result.Id);
    }

}