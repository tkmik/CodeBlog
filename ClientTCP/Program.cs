using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientTCP
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

            Console.WriteLine($"Enter a message");
            var message = Console.ReadLine();
            var data = Encoding.UTF8.GetBytes(message);
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);

            var buffer = new byte[1024];
            var size = 0;
            var answer = new StringBuilder();

            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (tcpSocket.Available > 0);
            Console.WriteLine($"{answer}");
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
            Console.ReadKey();

        }
    }
}
