using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRClient
{
    class Program
    {
        static HubConnection HubConnection;
        static async Task Main(string[] args)
        {

            var connection = new HubConnectionBuilder().WithUrl("http://localhost:5000/notification").Build();

            connection.On<string>("Receive", message => {
                Console.WriteLine($"SIGNALR:   Получено сообщение от сервера: {message}");
            });

            await connection.StartAsync();
            Console.WriteLine($"SIGNALR:   Соединение с сервером установлено");

            var msg = "1234_4321";
            await connection.SendAsync("SendMessage", msg);
            Console.WriteLine($"SIGNALR:   Сообщение было отправлено на сервер: {msg}");

            Console.ReadLine();
        }
    }
}
