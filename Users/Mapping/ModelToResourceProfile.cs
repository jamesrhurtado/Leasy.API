using AutoMapper;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Resources;

namespace Leasy.API.Users.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
    }
    
}