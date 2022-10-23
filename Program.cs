using Leasy.API.Shared.Domain.Repositories;
using Leasy.API.Shared.Persistence.Contexts;
using Leasy.API.Shared.Persistence.Repositories;
using Leasy.API.Users.Domain.Repositories;
using Leasy.API.Users.Domain.Services;
using Leasy.API.Users.Mapping;
using Leasy.API.Users.Persistence.Repositories;
using Leasy.API.Users.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Leasy Project API",
        Description = "Leasy Project RESTful API",
        TermsOfService = new Uri("https://leasy.com"),
        Contact = new OpenApiContact
        {
            Name = "Leasy Project",
            Url = new Uri("https://leasy.com")
        },
        License = new OpenApiLicense
        {
            Name = "Leasy Project Resources License",
            Url = new Uri("https://leasy.com/license")
        }
    });
    options.EnableAnnotations();
});



// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Database Connection with Sensitive and Detailed Information and Errors enabled

//builder.Services.AddDbContext<AppDbContext>(
//    options => options.UseMySQL(connectionString)
//        .LogTo(Console.WriteLine, LogLevel.Information)
//        .EnableSensitiveDataLogging()
//        .EnableDetailedErrors());

// Database Connection with Standard Level for Information and Errors

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

// Add lowercase routes

builder.Services.AddRouting(options => 
    options.LowercaseUrls = true);

// Dependency Injection Configuration

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));


var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
