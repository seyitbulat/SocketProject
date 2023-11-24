using Microsoft.AspNetCore.SignalR;

namespace SocketProject.Api.Hubs
{
	public sealed class ChatHub : Hub
	{
        public List<string> Messages { get; set; }

        public override async Task OnConnectedAsync()
		{
			await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} girdi");
			Messages = new();
		}


		public async Task SendMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}


		public async Task JoinPrivateChat(string user1, string user2)
		{
			string groupName = $"{user1}-{user2}";
			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
		}


		public async Task SendMessageToPrivateChat(string user1, string user2, string message)
		{
			string groupName = $"{user1}-{user2}";
			await Clients.Group(groupName).SendAsync(user1, user2, message);
		}

		public async Task RemovePrivateChat(string user)
		{
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user);
        }

		public async Task GetMessages(string user)
		{

		}
	}
}
