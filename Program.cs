using Leasy.API.Reports.Domain.Repositories;
using Leasy.API.Reports.Domain.Services;
using Leasy.API.Reports.Persistence.Repositories;
using Leasy.API.Reports.Services;
using Leasy.API.Security.Authorization.Handlers.Implementations;
using Leasy.API.Security.Authorization.Handlers.Interfaces;
using Leasy.API.Security.Authorization.Middleware;
using Leasy.API.Security.Authorization.Settings;
using Leasy.API.Shared.Domain.Repositories;
using Leasy.API.Shared.Persistence.Contexts;
using Leasy.API.Shared.Persistence.Repositories;
using Leasy.API.Users.Domain.Repositories;
using Leasy.API.Users.Domain.Services;
using Leasy.API.Users.Persistence.Repositories;
using Leasy.API.Users.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add CORS service

builder.Services.AddCors();

// AppSettings Configuration

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

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

// Shared Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// User Injection Configuration

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserSettingsService, UserSettingsService>();
builder.Services.AddScoped<IUserSettingsRepository, UserSettingsRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportService, ReportService>();


// Security Injection Configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();


// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(Leasy.API.Users.Mapping.ModelToResourceProfile),
    typeof(Leasy.API.Users.Mapping.ResourceToModelProfile),
    typeof(Leasy.API.Reports.Mapping.ResourceToModelProfile),
    typeof(Leasy.API.Reports.Mapping.ResourceToModelProfile)
);


var app = builder.Build();

// Configure CORS

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


// Configure Error Handler Middleware

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure JWT Handling Middleware

app.UseMiddleware<JwtMiddleware>();

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
