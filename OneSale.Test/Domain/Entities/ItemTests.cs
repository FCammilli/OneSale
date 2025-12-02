using OneSale.Domain.Entities;
using OneSale.Domain.ValueObjects;

namespace OneSale.Test.Domain.Entities
{
    public class ItemTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Product A", 99.99m);
            var quantity = Quantity.From(5);
            var discountedPrice = 89.99m;

            // Act
            var item = new Item(product, quantity, discountedPrice);

            // Assert
            Assert.Equal(product, item.Product);
            Assert.Equal(quantity, item.Quantity);
            Assert.Equal(discountedPrice, item.DiscountedPrice);
        }
    }
}