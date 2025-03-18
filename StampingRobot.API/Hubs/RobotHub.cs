using Microsoft.AspNetCore.SignalR;
using StamingRobot.Repository.Entities;

namespace StampingRobot.API.Hubs
{
    public class RobotHub : Hub
    {
        public async Task SendToRobot(string action)
        {
            await Clients.All.SendAsync("Send", action);
        }
    }
}
