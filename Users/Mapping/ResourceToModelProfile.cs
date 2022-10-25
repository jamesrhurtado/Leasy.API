using AutoMapper;
using Leasy.API.Security.Domain.Services.Communication;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Resources;

namespace Leasy.API.Users.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();

        CreateMap<UpdateRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }
            ));
    }
}