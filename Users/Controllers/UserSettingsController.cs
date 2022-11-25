using AutoMapper;
using Leasy.API.Shared.Extensions;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Domain.Services;
using Leasy.API.Users.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasy.API.Users.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/v1/users/settings")]
public class UserSettingsController: ControllerBase
{
    private readonly IUserSettingsService _userSettingsService;
    private readonly IMapper _mapper;

    public UserSettingsController(IUserSettingsService userSettingsService, IMapper mapper)
    {
        _userSettingsService = userSettingsService;
        _mapper = mapper;
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Settings By Id",
        Description = "Get a settings data already stored.",
        Tags = new[] {"Settings"})]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _userSettingsService.GetById(id);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result.Resource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Record Settings For A User",
        Description = "Record the settings for a given User",
        Tags = new[] {"Settings"})]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserSettingsResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var userSettings = _mapper.Map<SaveUserSettingsResource, UserSettings>(resource);
        var result = await _userSettingsService.SaveAsync(userSettings);

        if (!result.Success)
            return BadRequest(result.Message);
            
        var userSettingsResource = _mapper.Map<UserSettings, UserSettingsResource>(result.Resource);

        return Ok(userSettingsResource);
    }
    
    [SwaggerOperation(
        Summary = "Update Settings For A User",
        Description = "Update the settings for a given User",
        Tags = new[] {"Settings"})]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserSettingsResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var userSettings = _mapper.Map<SaveUserSettingsResource, UserSettings>(resource);

        var result = await _userSettingsService.UpdateAsync(id, userSettings);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var userSettingsResource = _mapper.Map<UserSettings, UserSettingsResource>(result.Resource);

        return Ok(userSettingsResource);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete Settings For A User",
        Description = "Delete the settings for a given User",
        Tags = new[] {"Settings"})]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userSettingsService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var userSettingsResource = _mapper.Map<UserSettings, UserSettingsResource>(result.Resource);

        return Ok(userSettingsResource);
    }
    
    
}