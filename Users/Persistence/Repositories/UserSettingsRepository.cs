using Leasy.API.Shared.Persistence.Contexts;
using Leasy.API.Shared.Persistence.Repositories;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Leasy.API.Users.Persistence.Repositories;

public class UserSettingsRepository: BaseRepository, IUserSettingsRepository
{
    public UserSettingsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UserSettings>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(UserSettings userSettings)
    {
        await _context.UserSettings.AddAsync(userSettings);
    }

    public async Task<UserSettings> FindByIdAsync(int id)
    {
        return await _context.UserSettings.FindAsync(id);
    }

    public async Task<UserSettings> FindByUserIdAsync(int userId)
    {
        return await _context.UserSettings.SingleOrDefaultAsync(C => C.UserId == userId);
    }

    public void Update(UserSettings userSettings)
    {
        _context.UserSettings.Update(userSettings);
    }

    public void Remove(UserSettings userSettings)
    {
        _context.UserSettings.Remove(userSettings);
    }
}