using Leasy.API.Security.Domain.Services.Communication;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Domain.Services.Communication;

namespace Leasy.API.Users.Domain.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest request);
    Task UpdateAsync(int id, UpdateRequest request);
    Task DeleteAsync(int id);
    
    //three are missing and will be implemented with security features
}