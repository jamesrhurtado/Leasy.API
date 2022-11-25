using Leasy.API.Reports.Domain.Services.Communication;
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
        var existingUserSettings = _userSettingsRepository.FindByIdAsync(id);
        if (existingUserSettings.Result == null)
        {
            return new UserSettingsResponse("The settings do not exist.");   
        }

        return new UserSettingsResponse(existingUserSettings.Result);
    }

    public async Task<UserSettingsResponse> GetByUserId(int userId)
    {
        var existingUserSettings = _userSettingsRepository.FindByUserIdAsync(userId);
        if (existingUserSettings.Result == null)
        {
            return new UserSettingsResponse("The settings do not exist.");   
        }
        return new UserSettingsResponse(existingUserSettings.Result);
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
  
        var existingUserSettings = await _userSettingsRepository.FindByIdAsync(id);

        if (existingUserSettings == null)
            return new UserSettingsResponse("User Settings not found.");

        existingUserSettings.Currency = userSettings.Currency;
        existingUserSettings.DaysPerYear = userSettings.DaysPerYear;
        existingUserSettings.ValueAddedTax = userSettings.ValueAddedTax;
        existingUserSettings.IncomeTax = userSettings.IncomeTax;

        try
        {
            _userSettingsRepository.Update(existingUserSettings);
            await _unitOfWork.CompleteAsync();

            return new UserSettingsResponse(existingUserSettings);
        }
        catch (Exception e)
        {
            return new UserSettingsResponse($"An error occurred while updating the settings: {e.Message}");
        }

    }

    public async Task<UserSettingsResponse> DeleteAsync(int id)
    {
        var existingUserSettings = await _userSettingsRepository.FindByIdAsync(id);
        if (existingUserSettings == null)
            return new UserSettingsResponse("User Settings not found");
        try
        {
            _userSettingsRepository.Remove(existingUserSettings);
            await _unitOfWork.CompleteAsync();
            return new UserSettingsResponse(existingUserSettings);
        }
        catch (Exception e)
        {
            return new UserSettingsResponse($"An error occurred while deleting the settings: {e.Message}");
        }
    }
}