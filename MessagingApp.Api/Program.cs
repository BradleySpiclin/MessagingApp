using MessagingApp.Api.Hubs;
using MessagingApp.Api.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure
builder.Services.AddInfrastructureModule(builder.Configuration);
builder.Services.AddApplicationModule();
builder.Services.AddHubModule();

// Add controllers and swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MessagingApp API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MessagingApp API V1");
    });
}

app.UseHttpsRedirection();

app.MapHub<ChatHub>("/chathub");
app.MapControllers();

// Log application startup using custom logger - we know our logger works correctly!!!
var customLogger = app.Services.GetRequiredService<MessagingApp.Infrastructure.ILogger>();
customLogger.Info(nameof(Program), nameof(app.Run), "Application started");

app.Run();
