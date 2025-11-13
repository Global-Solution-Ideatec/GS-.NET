using IdeaTecAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
});

// Configure URLs
builder.WebHost.UseUrls("https://localhost:5001", "http://localhost:5000");

var app = builder.Build();

// Serve Swagger UI at the application root so visiting '/' opens the UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdeaTecAPI v1");
    c.RoutePrefix = string.Empty; // serve UI at '/'
});

app.UseAuthorization();
app.MapControllers();
app.Run();
