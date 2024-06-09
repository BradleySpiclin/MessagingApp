using MessagingApp.Infrastructure;
using ILogger = MessagingApp.Infrastructure.ILogger;

namespace MessagingApp.Api.Infrastructure;

public static class LoggingModule
{
    public static void AddLoggingModule(this IServiceCollection services)
    {
        services.AddSingleton<ILogger, Logger>();
    }
}
