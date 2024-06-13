using MessagingApp.Api.Hubs;

namespace MessagingApp.Api.Infrastructure;

public static class HubModule
{
    public static void AddHubModule(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddSingleton<ChatHub>();
    }
}
