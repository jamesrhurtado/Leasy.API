using System.ComponentModel.DataAnnotations;

namespace Leasy.API.Users.Resources;

public class SaveUserResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(25)]
    public string Password { get; set; }
}