using AutoMapper;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Domain.Services;
using Leasy.API.Users.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasy.API.Users.Controllers;
[Produces("application/json")]
[ApiController]
[Route("api/v1/users/{userId}/settings")]
public class UserUserSettingsController: ControllerBase
{
    private readonly IUserSettingsService _userSettingsService;
    private readonly IMapper _mapper;

    public UserUserSettingsController(IUserSettingsService userSettingsService, IMapper mapper)
    {
        _userSettingsService = userSettingsService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Settings For A User",
        Description = "Get the settings for a given UserId",
        Tags = new[] {"Settings"})]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var userSettings = await _userSettingsService.GetByUserId(userId);
        if (!userSettings.Success)
            return BadRequest(userSettings.Message);
        return Ok(userSettings.Resource);
    }

}