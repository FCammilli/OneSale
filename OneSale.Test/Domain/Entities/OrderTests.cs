using OneSale.Domain.Entities;

namespace OneSale.Test.Domain.Entities
{
    public class OrderTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var user = new User(Guid.NewGuid(), "John Doe", "john.doe@example.com");
            var items = new List<Item>();
            var total = 199.99m;

            // Act
            var order = new Order(id, user, items, total);

            // Assert
            Assert.Equal(id, order.Id);
            Assert.Equal(user, order.User);
            Assert.Equal(items, order.Items);
            Assert.Equal(total, order.Total);
        }
    }
}