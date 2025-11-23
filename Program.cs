using IdeaTecAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<IdeaTecContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IdeaTecAPI", Version = "v1" });
    // Add API Key support to Swagger
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key needed to access the endpoints. Use header 'X-API-KEY'",
        Name = "X-API-KEY",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "ApiKey" },
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// Configure URLs: prefer ASPNETCORE_URLS if provided (useful in Docker)
var aspnetUrls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
if (!string.IsNullOrEmpty(aspnetUrls))
{
    builder.WebHost.UseUrls(aspnetUrls);
}
else
{
    builder.WebHost.UseUrls("https://localhost:5001", "http://localhost:5000");
}

var app = builder.Build();

// Serve Swagger UI at the application root so visiting '/' opens the UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdeaTecAPI v1");
    c.RoutePrefix = string.Empty; // serve UI at '/'
});

// Simple API Key middleware: checks for header X-API-KEY and compares with configuration
var configuredApiKey = app.Configuration["ApiKey"];
app.Use(async (context, next) =>
{
    var path = context.Request.Path;
    // allow swagger and root without api key
    if (path.StartsWithSegments("/swagger") || path == "/" || path.StartsWithSegments("/favicon.ico"))
    {
        await next();
        return;
    }

    if (!string.IsNullOrEmpty(configuredApiKey))
    {
        if (!context.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKey) || extractedApiKey != configuredApiKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("API Key missing or invalid.");
            return;
        }
    }

    await next();
});

app.UseAuthorization();
app.MapControllers();
app.Run();
