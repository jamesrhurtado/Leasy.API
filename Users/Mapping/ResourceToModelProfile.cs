using AutoMapper;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Resources;

namespace Leasy.API.Users.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveUserResource, User>();
    }
}