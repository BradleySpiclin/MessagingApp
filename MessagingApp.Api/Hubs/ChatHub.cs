using Microsoft.AspNetCore.SignalR;

using ILogger = MessagingApp.Infrastructure.ILogger;

namespace MessagingApp.Api.Hubs;

public class ChatHub : Hub
{
    private readonly ILogger _logger;

    private static readonly List<string> StaticGroups = ["Group1", "Group2", "Group3"];

    public ChatHub(ILogger logger)
    {
        _logger = logger;
    }

    public async Task SendMessage(string user, string message)
    {
        _logger.Info(nameof(ChatHub), nameof(SendMessage), $"Message from {user}: {message}");

        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task JoinGroup(string groupName)
    {
        if (StaticGroups.Contains(groupName))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            _logger.Info(nameof(ChatHub), nameof(JoinGroup), $"{Context.ConnectionId} joined the group {groupName}");

            await Clients.Group(groupName)
                .SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined the group {groupName}.");
        }
    }

    public async Task LeaveGroup(string groupName)
    {
        if (StaticGroups.Contains(groupName))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            _logger.Info(nameof(ChatHub), nameof(LeaveGroup), $"{Context.ConnectionId} left the group {groupName}");

            await Clients.Group(groupName)
                .SendAsync("ReceiveMessage", $"{Context.ConnectionId} has left the group {groupName}.");
        }
    }

    public async Task SendMessageToGroup(string groupName, string user, string message)
    {
        if (StaticGroups.Contains(groupName))
        {
            _logger.Info(nameof(ChatHub), nameof(SendMessageToGroup), $"Message to {groupName} from {user}: {message}");

            await Clients.Group(groupName)
                .SendAsync("ReceiveMessage", user, message);
        }
    }
}
