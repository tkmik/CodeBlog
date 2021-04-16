using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerUDP
{
    class Program
    {
        const string IP = "127.0.0.1";
        const int PORT = 8081;
        static void Main(string[] args)
        {
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);
            // for UDP
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(udpEndPoint);

            while (true)
            {
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
                udpSocket.SendTo(Encoding.UTF8.GetBytes("Message has sent"), senderEndPoint);

                Console.WriteLine($"{data}");
            }            
        }
    }
}
