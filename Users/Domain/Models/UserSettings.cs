namespace Leasy.API.Users.Domain.Models;

public class UserSettings
{
    public int Id { get; set; }
    public string Currency { get; set; }
    public int DaysPerYear { get; set; }
    public decimal ValueAddedTax { get; set; }
    public decimal IncomeTax { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}