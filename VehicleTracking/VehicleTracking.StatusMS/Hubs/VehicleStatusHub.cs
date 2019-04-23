using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace VehicleTracking.StatusMS.Hubs
{
    public class VehicleStatusHub : Hub
    {
        public async Task GetStatus(string message)
        {
            await Clients.All.SendAsync("acknowledgeMessage", message);
        }
    }
}