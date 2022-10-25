using Leasy.API.Shared.Domain.Services.Communication;
using Leasy.API.Users.Domain.Models;

namespace Leasy.API.Users.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(User user): base(user) {}
    
    public UserResponse(string message): base(message) {}
    
}