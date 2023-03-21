using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectRIT.TCP
{
    public class TcpServer
    {
        private TcpListener? _listener;

        public async void Start(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            Console.WriteLine($"TCP: Started TcpListener on port: {port}");
            AcceptTcpClient();
        }

        private async Task AcceptTcpClient()
        {
            while (true)
            {
                using var tcpClient = await _listener.AcceptTcpClientAsync();
                Console.WriteLine($"Входящее подключение: {tcpClient.Client.RemoteEndPoint}");

                byte[] bytes = new byte[256];
                NetworkStream stream = tcpClient.GetStream();
                int i;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine($"Получено сообщение: {data}");
                }
            }
        }
    }
}
