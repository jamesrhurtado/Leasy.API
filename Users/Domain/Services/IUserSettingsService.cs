using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Domain.Services.Communication;

namespace Leasy.API.Users.Domain.Services;

public interface IUserSettingsService
{
    Task<IEnumerable<UserSettings>> ListAsync();
    Task<UserSettingsResponse> GetById(int id);
    Task<UserSettingsResponse> SaveAsync(UserSettings userSettings);
    Task<UserSettingsResponse> UpdateAsync(int id, UserSettings userSettings);
    Task<UserSettingsResponse> DeleteAsync(int id);
}