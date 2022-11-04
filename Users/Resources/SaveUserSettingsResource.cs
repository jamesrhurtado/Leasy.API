using System.ComponentModel.DataAnnotations;

namespace Leasy.API.Users.Resources;

public class SaveUserSettingsResource
{
    [Required]
    public string Currency { get; set; }
    
    [Required]
    public int DaysPerYear { get; set; }
    
    [Required]
    public decimal ValueAddedTax { get; set; }
    
    [Required]
    public decimal IncomeTax { get; set; }
    
    [Required]
    public int UserId { get; set; }
}