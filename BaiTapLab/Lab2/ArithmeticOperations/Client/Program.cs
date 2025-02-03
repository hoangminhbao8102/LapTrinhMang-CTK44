using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Đang kết nối với server...");

            try
            {
                serverSocket.Connect(serverEndPoint);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Không thể kết nối đến server");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            if (serverSocket.Connected)
            {
                Console.WriteLine("Kết nối thành công với server...");

                byte[] buff = new byte[1024];
                int byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                string str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);

                while (true)
                {
                    // Đọc dữ liệu từ console và gửi tới server
                    str = Console.ReadLine();

                    if (str.ToLower() == "exit")
                    {
                        Console.WriteLine("Đang ngắt kết nối...");
                        break;
                    }

                    buff = Encoding.ASCII.GetBytes(str);
                    serverSocket.Send(buff, 0, buff.Length, SocketFlags.None);

                    // Nhận dữ liệu từ server
                    buff = new byte[1024];
                    byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                    str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                    Console.WriteLine(str);
                }
            }

            serverSocket.Close();
            Console.WriteLine("Client đã ngắt kết nối.");
            Console.ReadKey();
        }
    }
}
