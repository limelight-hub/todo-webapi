using Microsoft.AspNetCore.SignalR;

namespace MyApi.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string sender, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", sender, message);
    }
}
