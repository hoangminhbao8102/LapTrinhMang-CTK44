using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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
            UdpClient server = new UdpClient(serverEndPoint);
            Console.WriteLine("Đang chờ client kết nối tới...");

            byte[] buffer;
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                // Nhận dữ liệu từ client
                buffer = server.Receive(ref clientEndPoint);
                string receivedData = Encoding.ASCII.GetString(buffer);
                Console.WriteLine("Nhận được từ phía client: " + receivedData);

                if (receivedData.Trim().ToLower() == "exit")
                {
                    Console.WriteLine("Client yêu cầu đóng kết nối.");
                    break;
                }
                else if (receivedData.Trim().ToLower() == "exit all")
                {
                    Console.WriteLine("Client yêu cầu đóng cả client và server.");
                    server.Close();
                    Console.WriteLine("Đã đóng server");
                    Environment.Exit(0); // Đóng ứng dụng server
                }

                // Gửi phản hồi lại cho client
                buffer = Encoding.ASCII.GetBytes("Server nhận được: " + receivedData);
                server.Send(buffer, buffer.Length, clientEndPoint);
            }

            Console.WriteLine("Đã đóng kết nối với client");
            server.Close();
        }
    }
}
