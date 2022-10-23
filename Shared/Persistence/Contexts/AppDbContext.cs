using Leasy.API.Shared.Extensions;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Resources;
using Microsoft.EntityFrameworkCore;

namespace Leasy.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    protected readonly IConfiguration _configuration;

    public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(250);
        builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(80);
        
        //Relationships
        
        
        // Apply Snake Case Naming Conventions
        
        builder.UseSnakeCaseNamingConvention();
    }

}