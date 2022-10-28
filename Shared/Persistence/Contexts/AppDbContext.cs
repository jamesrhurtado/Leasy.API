using Leasy.API.Reports.Domain.Models;
using Leasy.API.Shared.Extensions;
using Leasy.API.Users.Domain.Models;
using Leasy.API.Users.Resources;
using Microsoft.EntityFrameworkCore;

namespace Leasy.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Report> Reports { get; set; }
    protected readonly IConfiguration _configuration;

    public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Users
        //Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(250);
        builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(80);
        
        //Relationships
        builder.Entity<User>()
            .HasMany(p => p.Reports)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        
        //Reports
        //Constraints
        builder.Entity<Report>().ToTable("Reports");
        builder.Entity<Report>().HasKey(p => p.Id);
        builder.Entity<Report>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Report>().Property(p => p.AssetPrice).IsRequired();
        builder.Entity<Report>().Property(p => p.LeasingTime).IsRequired();
        builder.Entity<Report>().Property(p => p.PaymentFrequency).IsRequired();
        builder.Entity<Report>().Property(p => p.RateType).IsRequired();
        builder.Entity<Report>().Property(p => p.RateValue).IsRequired();
        builder.Entity<Report>().Property(p => p.Capitalization);
        builder.Entity<Report>().Property(p => p.BuybackPercentage);
        builder.Entity<Report>().Property(p => p.NotaryFees);
        builder.Entity<Report>().Property(p => p.RegistryFees);
        builder.Entity<Report>().Property(p => p.Valuation);
        builder.Entity<Report>().Property(p => p.StudyCommission);
        builder.Entity<Report>().Property(p => p.ActivationCommission);
        builder.Entity<Report>().Property(p => p.RegularCommission);
        builder.Entity<Report>().Property(p => p.RiskInsurancePercentage);
        builder.Entity<Report>().Property(p => p.DiscountRateKs).IsRequired();
        builder.Entity<Report>().Property(p => p.DiscountRateWacc).IsRequired();
        
        
        // Apply Snake Case Naming Conventions
        
        builder.UseSnakeCaseNamingConvention();
    }

}