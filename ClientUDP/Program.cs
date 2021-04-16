using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientUDP
{
    class Program
    {
        const string IP = "127.0.0.1";
        const int PORT = 8082;
        static void Main(string[] args)
        {
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);
            // for UDP
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(udpEndPoint);

            while (true)
            {
                Console.WriteLine($"Enter a message");
                var message = Console.ReadLine();
                var serverEndPoint = new IPEndPoint(IPAddress.Parse(IP), 8081);
                udpSocket.SendTo(Encoding.UTF8.GetBytes(message), serverEndPoint);

                var buffer = new byte[1024];
                var size = 0;
                var data = new StringBuilder();
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

                do
                {

                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(buffer));

                }
                while (udpSocket.Available > 0);

                Console.WriteLine($"{data}");
            }
        }
    }
}
