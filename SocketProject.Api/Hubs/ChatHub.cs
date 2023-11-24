using Microsoft.AspNetCore.SignalR;

namespace SocketProject.Api.Hubs
{
	public sealed class ChatHub : Hub
	{
		//public override async Task OnConnectedAsync()
		//{
		//	await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} girdi");
		//}


		public async Task SendMessage(string user, string message, Guid group)
		{
			await Clients.Group(group.ToString()).SendAsync("ReceiveMessage", user, message);
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
	}
}
