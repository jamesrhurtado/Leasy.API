using AutoMapper;
using Leasy.API.Security.Authorization.Attributes;
using Leasy.API.Security.Domain.Services.Communication;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Domain.Services;
using Leasy.API.Users.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Leasy.API.Users.Controllers;
[Produces("application/json")]
[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController: ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Records a user login",
        Description = "Returns the data of an application user along with a hash password that identifies it.",
        Tags = new[] {"Users"})]
    [HttpPost("sign-in")]
    public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest request)
    {
        var response = await _userService.Authenticate(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Registers a new user",
        Description = "Register a new user in the database.",
        Tags = new[] {"Users"})]
    [HttpPost("sign-up")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Users",
        Description = "Get All Users already stored",
        Tags = new[] {"Users"})]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return Ok(resources);
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a user by Id",
        Description = "Get a User Data already stored",
        Tags = new[] {"Users"})]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<User, UserResource>(user);
        return Ok(resource);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Edit a user",
        Description = "Updates the data of a stored user given its id.",
        Tags = new[] {"Users"})]
    public async Task<IActionResult> UpdateAsync(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a user",
        Description = "Delete the data of a stored user given its id",
        Tags = new[] {"User"})]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }   
}