using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SafeShopAPI.Data;
using SafeShopAPI.Data.Repository;
using SafeShopAPI.DependencyInjection;
using SafeShopAPI.Domain.Interfaces;
using SafeShopAPI.Services;
using SafeShopAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

builder.Services.AddDbContext<SafeShopContext>(options =>
    options.UseInMemoryDatabase("SafeShopDb")
);

#region Services
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion

builder
    .Services.AddEndpointsApiExplorer()
    .AddSwaggerConfiguration()
    .AddSwagerAuthentication(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SafeShopContext>();
    dbContext.Database.EnsureCreated(); // Ensures the database and the seed data is created
}

app.Run();
