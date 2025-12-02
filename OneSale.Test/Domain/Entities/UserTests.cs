using OneSale.Domain.Entities;

namespace OneSale.Test.Domain.Entities
{
    public class UserTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "John Doe";
            var email = "john.doe@example.com";

            // Act
            var user = new User(id, name, email);

            // Assert
            Assert.Equal(id, user.Id);
            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email);
        }
    }
}