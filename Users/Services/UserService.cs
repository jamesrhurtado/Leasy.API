using Leasy.API.Shared.Domain.Repositories;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Domain.Repositories;
using Leasy.API.Users.Domain.Services;
using Leasy.API.Users.Domain.Services.Communication;

namespace Leasy.API.Users.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<User>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResponse> FindById(int id)
    {
        throw new NotImplementedException();
    }
}