namespace Leasy.API.Users.Resources;

public class UserSettingsResource
{
    public int Id { get; set; }
    public string Currency { get; set; }
    public int DaysPerYear { get; set; }
    public decimal ValueAddedTax { get; set; }
    public decimal IncomeTax { get; set; }
}