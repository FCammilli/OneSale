using OneSale.Domain.Entities;

namespace OneSale.Test.Domain.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Product A";
            var price = 99.99m;

            // Act
            var product = new Product(id, name, price);

            // Assert
            Assert.Equal(id, product.Id);
            Assert.Equal(name, product.Name);
            Assert.Equal(price, product.Price);
        }
    }
}