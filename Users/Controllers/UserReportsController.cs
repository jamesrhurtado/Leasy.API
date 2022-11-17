using AutoMapper;
using Leasy.API.Reports.Domain.Models;
using Leasy.API.Reports.Domain.Services;
using Leasy.API.Reports.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasy.API.Users.Controllers;

[Route("api/v1/users/{userId}/reports")]
public class UserReportsController : ControllerBase
{
    private readonly IReportService _reportService;
    private readonly IMapper _mapper;

    public UserReportsController(IReportService reportService, IMapper mapper)
    {
        _reportService = reportService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Reports By User",
        Description = "Get all reports for a given UserId",
        Tags = new[] {"Reports"})]
    public async Task<IEnumerable<ReportResource>>GetAllByUserId(int userId)
    {
        var reports = await _reportService.ListByUserIdAsync(userId);
        var resources = _mapper
            .Map<IEnumerable<Report>, IEnumerable<ReportResource>>(reports);
        return resources;
    }
}