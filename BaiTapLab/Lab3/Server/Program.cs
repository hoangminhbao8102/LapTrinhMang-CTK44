using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverSocket.Bind(serverEndPoint);
            Console.WriteLine("Đang chờ client kết nối tới...");

            byte[] buff = new byte[1024];
            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            string str;

            for (int i = 1; i <= 5; i++)
            {
                int byteReceive = serverSocket.ReceiveFrom(buff, ref remoteEndPoint);
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine("Nhận được từ phía client: " + str);
            }

            while (true)
            {
                // Nhận dữ liệu từ client
                int byteReceive = serverSocket.ReceiveFrom(buff, ref remoteEndPoint);
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine("Client: " + str);

                if (str.Trim().ToLower() == "exit")
                {
                    Console.WriteLine("Client yêu cầu đóng kết nối.");
                    break;
                }
                else if (str.Trim().ToLower() == "exit all")
                {
                    Console.WriteLine("Client yêu cầu đóng cả client và server.");
                    serverSocket.Close();
                    Console.WriteLine("Đã đóng server");
                    Environment.Exit(0); // Đóng ứng dụng server
                }

                // Gửi phản hồi lại cho client
                serverSocket.SendTo(buff, 0, byteReceive, SocketFlags.None, remoteEndPoint);

                // Xử lý nhập từ người dùng trên server
                string input = Console.ReadLine();
                if (input == "exit")
                    break;

                serverSocket.SendTo(Encoding.ASCII.GetBytes(input), remoteEndPoint);

                byte[] data = new byte[10];
                int recv;
                try
                {
                    recv = serverSocket.ReceiveFrom(data, ref remoteEndPoint);
                    string stringData = Encoding.ASCII.GetString(data, 0, recv);
                    Console.WriteLine(stringData);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Cảnh báo: Dữ liệu bị mất, hãy thử lại.");
                    data = new byte[data.Length + 10];
                }
            }

            Console.WriteLine("Đã đóng kết nối với client");
        }
    }
}
