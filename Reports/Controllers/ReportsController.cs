using AutoMapper;
using Leasy.API.Reports.Domain.Models;
using Leasy.API.Reports.Domain.Services;
using Leasy.API.Reports.Resources;
using Leasy.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasy.API.Reports.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
public class ReportsController: ControllerBase
{
    private readonly IReportService _reportService;
    private readonly IMapper _mapper;

    public ReportsController(IReportService reportService, IMapper mapper)
    {
        _reportService = reportService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All reports",
        Description = "Get all reports already stored",
        Tags = new[] {"Reports"})]
    public async Task<IEnumerable<ReportResource>> GetAllAsync()
    {
        var reports = await _reportService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Report>, IEnumerable<ReportResource>>(reports);
        return resources;
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Report By Id",
        Description = "Get a report from the database identified by its id.",
        Tags = new[] {"Reports"})]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _reportService.GetById(id);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result.Resource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Register A Report",
        Description = "Add a report to a service in the database.",
        Tags = new[] {"Reports"})]
    public async Task<IActionResult> PostAsync([FromBody] SaveReportResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var report = _mapper.Map<SaveReportResource, Report>(resource);
        var result = await _reportService.SaveAsync(report);

        if (!result.Success)
            return BadRequest(result.Message);
            
        var reportResource = _mapper.Map<Report, ReportResource>(result.Resource);

        return Ok(reportResource);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Edit a report",
        Description = "Edit a report in the database.",
        Tags = new[] {"Reports"})]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReportResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var report = _mapper.Map<SaveReportResource, Report>(resource);

        var result = await _reportService.UpdateAsync(id, report);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var reportResource = _mapper.Map<Report, ReportResource>(result.Resource);

        return Ok(reportResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a report",
        Description = "Delete a report in the database.",
        Tags = new[] {"Reports"})]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _reportService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var reportResource = _mapper.Map<Report, ReportResource>(result.Resource);

        return Ok(reportResource);
    }

}