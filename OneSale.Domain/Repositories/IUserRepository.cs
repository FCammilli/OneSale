using OneSale.Domain.Entities;

namespace OneSale.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
}