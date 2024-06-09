using System.Diagnostics;
using MessagingApp.Api.Hubs;
using MessagingApp.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add Modules from infra
builder.Services.AddLoggingModule();
builder.Services.AddHubModule();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHub<ChatHub>("/chathub");

// Log application startup using custom logger - we know our logger works correctly!!!
var customLogger = app.Services.GetRequiredService<MessagingApp.Infrastructure.ILogger>();
customLogger.Info(nameof(Program), nameof(app.Run), "Application started");

app.Run();


