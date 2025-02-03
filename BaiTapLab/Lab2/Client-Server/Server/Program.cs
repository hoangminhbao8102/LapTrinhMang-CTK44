using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);

            Console.WriteLine("Đang cho kết nối từ client...");
            Socket clientSocket = serverSocket.Accept();
            EndPoint clientEndPoint = clientSocket.RemoteEndPoint;
            byte[] buff;

            // Gửi thông điệp chào mừng client
            string hello = "Hello Client";
            buff = Encoding.ASCII.GetBytes(hello);
            clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);
            Console.WriteLine("Kết nối thành công với client: " + clientEndPoint.ToString());

            while (true)
            {
                try
                {
                    // Nhận dữ liệu từ client
                    buff = new byte[1024];
                    int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                    string str = Encoding.ASCII.GetString(buff, 0, byteReceive);

                    if (str.ToLower() == "exit")
                    {
                        Console.WriteLine("Client đã ngắt kết nối.");
                        break;
                    }

                    Console.WriteLine("Client: " + str);

                    // Gửi dữ liệu trả lời cho client
                    buff = Encoding.ASCII.GetBytes("Server nhận được: " + str);
                    clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("Client đã ngắt kết nối.");
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            clientSocket.Close();
            serverSocket.Close();
        }
    }
}
