using Leasy.API.Shared.Domain.Services.Communication;
using Leasy.API.Users.Domain.Models;

namespace Leasy.API.Users.Domain.Services.Communication;

public class UserSettingsResponse: BaseResponse<UserSettings>
{
    public UserSettingsResponse(UserSettings userSettings): base(userSettings){}
    
    public UserSettingsResponse(string message): base(message) {}
    
}