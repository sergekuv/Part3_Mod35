using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Part3_Mod35.Hubs
{
    public class ChatHub : Hub
    {
        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
        public async Task SendMessage(string fromUser, string toUser, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", fromUser, toUser, message);
        }

    }
}
