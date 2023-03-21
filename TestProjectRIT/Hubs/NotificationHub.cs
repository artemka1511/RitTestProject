using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectRIT.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SendMessage(string message)
        {
            Console.WriteLine($"SIGNALR:   Получено сообщение от клиента: {message}");
            Console.WriteLine($"SIGNALR:   Рассылаю это сообщение всем клиентам");
            return Clients.All.SendAsync("Receive", message);
        }
    }
}
