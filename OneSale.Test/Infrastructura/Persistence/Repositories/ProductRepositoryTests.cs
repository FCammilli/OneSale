using Microsoft.EntityFrameworkCore;
using OneSale.Domain.Entities;
using OneSale.Infrastructure.Persistence;
using OneSale.Infrastructure.Persistence.Repositories;

namespace OneSale.Tests.Infrastructure.Persistence.Repositories;
public class ProductRepositoryTests
{
    private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

    public ProductRepositoryTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange
        using var context = new ApplicationDbContext(_dbContextOptions);
        var repository = new ProductRepository(context);
        var product = new Product(Guid.NewGuid(), "Test Product", 100.0m);
        context.Products.Add(product);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetByIdAsync(product.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(product.Id, result.Id);
        Assert.Equal(product.Name, result.Name);
        Assert.Equal(product.Price, result.Price);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenProductDoesNotExist()
    {
        // Arrange
        using var context = new ApplicationDbContext(_dbContextOptions);
        var repository = new ProductRepository(context);

        // Act
        var result = await repository.GetByIdAsync(Guid.NewGuid());

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task AddAsync_ShouldAddProductToDatabase()
    {
        // Arrange
        using var context = new ApplicationDbContext(_dbContextOptions);
        var repository = new ProductRepository(context);
        var product = new Product(Guid.NewGuid(), "New Product", 50.0m);

        // Act
        await repository.AddAsync(product);

        // Assert
        var addedProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
        Assert.NotNull(addedProduct);
        Assert.Equal(product.Id, addedProduct.Id);
        Assert.Equal(product.Name, addedProduct.Name);
        Assert.Equal(product.Price, addedProduct.Price);
    }

}
