using AutoMapper;
using Leasy.API.Reports.Domain.Models;
using Leasy.API.Reports.Resources;

namespace Leasy.API.Reports.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveReportResource, Report>();
    }
}