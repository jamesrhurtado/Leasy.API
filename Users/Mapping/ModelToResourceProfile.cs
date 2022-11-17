using AutoMapper;
using Leasy.API.Security.Domain.Services.Communication;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Resources;

namespace Leasy.API.Users.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
        CreateMap<UserSettings, UserSettingsResource>();
    }
    
}