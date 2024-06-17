using MessagingApp.Application;
using MessagingApp.Interfaces;

namespace MessagingApp.Api.Infrastructure;

public static class ApplicationModule
{
    public static void AddApplicationModule(this IServiceCollection services)
    {
        services.AddScoped<IGroupService, GroupService>();
    }
}
