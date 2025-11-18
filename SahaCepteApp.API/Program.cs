using SahaCepteApp.API.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureDbConnection(builder.Configuration);
builder.Services.ConfigureInfrastructureServices();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureAppContext();
builder.Services.AddCustomSwagger();

builder.Services.AddControllers();

var app = builder.Build();

await app.AddSeedData();

app.UseSwagger(options =>
{
    options.RouteTemplate = "openapi/{documentName}.json";
});

app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();