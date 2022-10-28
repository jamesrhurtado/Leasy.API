using AutoMapper;
using Leasy.API.Reports.Domain.Models;
using Leasy.API.Reports.Domain.Services;
using Leasy.API.Reports.Resources;
using Leasy.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IEnumerable<ReportResource>> GetAllAsync()
    {
        var reports = await _reportService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Report>, IEnumerable<ReportResource>>(reports);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _reportService.GetById(id);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result.Resource);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveReportResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var service = _mapper.Map<SaveReportResource, Report>(resource);
        var result = await _reportService.SaveAsync(service);

        if (!result.Success)
            return BadRequest(result.Message);
            
        var serviceResource = _mapper.Map<Report, ReportResource>(result.Resource);

        return Ok(serviceResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReportResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var category = _mapper.Map<SaveReportResource, Report>(resource);

        var result = await _reportService.UpdateAsync(id, category);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<Report, ReportResource>(result.Resource);

        return Ok(categoryResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _reportService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<Report, ReportResource>(result.Resource);

        return Ok(categoryResource);
    }

}