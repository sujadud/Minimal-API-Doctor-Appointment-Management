using AMS.MinimalAPI.Extensions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Apply Extensions
builder.Services.ConfigureDatabase(configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwtAuthentication(configuration);
builder.Services.ConfigureApplicationServices();
builder.Services.AddAuthorization();

var app = builder.Build();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
