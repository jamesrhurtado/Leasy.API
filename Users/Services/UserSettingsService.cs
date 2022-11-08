using Leasy.API.Shared.Domain.Repositories;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Domain.Repositories;
using Leasy.API.Users.Domain.Services;
using Leasy.API.Users.Domain.Services.Communication;

namespace Leasy.API.Users.Services;

public class UserSettingsService: IUserSettingsService
{

    private readonly IUserSettingsRepository _userSettingsRepository;
    private readonly IUnitOfWork _unitOfWork;


    public UserSettingsService(IUserSettingsRepository userSettingsRepository, IUnitOfWork unitOfWork)
    {
        _userSettingsRepository = userSettingsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserSettings>> ListAsync()
    {
        return await _userSettingsRepository.ListAsync();
    }

    public async Task<UserSettingsResponse> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserSettingsResponse> SaveAsync(UserSettings userSettings)
    {
        try
        {
            await _userSettingsRepository.AddAsync(userSettings);
            await _unitOfWork.CompleteAsync();

            return new UserSettingsResponse(userSettings);
        }
        catch (Exception e)
        {
            return new UserSettingsResponse($"An error occurred while saving the settings: {e.Message}");
        }
    }

    public async Task<UserSettingsResponse> UpdateAsync(int id, UserSettings userSettings)
    {
        /*
        var existingUserSettings = await _userSettingsRepository.FindByIdAsync(id);

        if (existingCategory == null)
            return new CategoryResponse("Category not found.");

        existingCategory.Name = category.Name;

        try
        {
            _categoryRepository.Update(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error occurred while updating the category: {e.Message}");
        }
        */
        return null;
    }

    public async Task<UserSettingsResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}