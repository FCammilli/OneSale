using Microsoft.EntityFrameworkCore;
using OneSale.Domain.Entities;
using OneSale.Infrastructure.Persistence;
using OneSale.Infrastructure.Persistence.Repositories;

namespace OneSale.Tests.Infrastructure.Persistence.Repositories
{
    public class UserRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public UserRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User(userId, "John Doe", "john.doe@example.com");

            await using var context = new ApplicationDbContext(_dbContextOptions);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            var userRepository = new UserRepository(context);

            // Act
            var result = await userRepository.GetByIdAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal("John Doe", result.Name);
            Assert.Equal("john.doe@example.com", result.Email);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = Guid.NewGuid();

            await using var context = new ApplicationDbContext(_dbContextOptions);
            var userRepository = new UserRepository(context);

            // Act
            var result = await userRepository.GetByIdAsync(userId);

            // Assert
            Assert.Null(result);
        }
    }
}