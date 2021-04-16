using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerTCP
{
    class Program
    {
        const string IP = "127.0.0.1";
        const int PORT = 8080;
        static void Main(string[] args)
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);
            // for TCP 
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5);

            while (true)
            {
                var listener = tcpSocket.Accept();
                var buffer = new byte[1024];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                } 
                while (listener.Available > 0);

                Console.WriteLine($"{data}");
                listener.Send(Encoding.UTF8.GetBytes("Succeed"));
                listener.Shutdown(SocketShutdown.Both); // turn off connection
                listener.Close();
            }
        }
    }
}
