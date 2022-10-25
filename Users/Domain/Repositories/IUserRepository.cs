using Leasy.API.Users.Domain.Models;

namespace Leasy.API.Users.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByEmailAsync(string email);
    bool ExistsByEmail(string email);
    User FindById(int id);
    void Update(User user);
    void Remove(User user);
}