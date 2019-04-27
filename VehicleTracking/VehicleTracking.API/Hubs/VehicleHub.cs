using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace VehicleTracking.API.Hubs
{
    public class VehicleHub : Hub
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
