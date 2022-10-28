using System.Text.Json.Serialization;
using Leasy.API.Reports.Domain.Models;

namespace Leasy.API.Users.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }
    
    //Relationships
    public IList<Report> Reports { get; set; }
}