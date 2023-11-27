using Microsoft.AspNetCore.SignalR;
using SocketProject.Api.Models;

namespace SocketProject.Api.Hubs
{
    public sealed class ChatHub : Hub
    {
        public HubManager manager { get; set; }

        public ChatHub(HubManager manager)
        {
            this.manager = manager;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }


        public async Task JoinPrivateChat(string user1, string user2)
        {
            var groupName = manager.AddGroup(user1, user2);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        }

        public async Task SendMessageToPrivateChat(string user1, string user2, string message)
        {
            var selected = manager.FindGroupByUsers(user1, user2);
            await Clients.Group(selected).SendAsync("ReceiveMessage", user1, user2, message);
        }

        public async Task RemovePrivateChat(string user)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user);
        }
    }
}
