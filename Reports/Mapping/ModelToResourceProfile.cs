using AutoMapper;
using Leasy.API.Reports.Domain.Models;
using Leasy.API.Reports.Resources;

namespace Leasy.API.Reports.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Report, ReportResource>();
    }
    
}