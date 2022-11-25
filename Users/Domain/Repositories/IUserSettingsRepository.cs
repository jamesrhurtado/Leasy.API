using Leasy.API.Users.Domain.Models;

namespace Leasy.API.Users.Domain.Repositories;

public interface IUserSettingsRepository
{
    Task<IEnumerable<UserSettings>> ListAsync();
    Task AddAsync(UserSettings userSettings);
    Task<UserSettings> FindByIdAsync(int id);
    Task<UserSettings> FindByUserIdAsync(int userId);
    void Update(UserSettings userSettings);
    void Remove(UserSettings userSettings);
}