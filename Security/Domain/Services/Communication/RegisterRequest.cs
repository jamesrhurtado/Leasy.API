using System.ComponentModel.DataAnnotations;

namespace Leasy.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required] public string Name { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}