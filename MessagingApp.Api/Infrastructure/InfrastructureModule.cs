using MessagingApp.Infrastructure;
using MessagingApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using ILogger = MessagingApp.Infrastructure.ILogger;

namespace MessagingApp.Api.Infrastructure;

public static class InfrastructureModule
{
    public static void AddInfrastructureModule(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("MessagingApp.Api")), ServiceLifetime.Scoped);

        services.AddScoped<IGroupRepository, GroupRepository>();

        services.AddTransient<ILogger, Logger>();
    }
}
