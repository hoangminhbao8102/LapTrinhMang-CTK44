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
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            UdpClient client = new UdpClient();
            client.Connect(serverEndPoint);

            string input;
            byte[] buffer;
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                Console.Write("Nhập thông điệp gửi tới server: ");
                input = Console.ReadLine();
                buffer = Encoding.ASCII.GetBytes(input);
                client.Send(buffer, buffer.Length);

                if (input.Trim().ToLower() == "exit" || input.Trim().ToLower() == "exit all")
                {
                    break;
                }

                buffer = client.Receive(ref remoteEndPoint);
                string response = Encoding.ASCII.GetString(buffer);
                Console.WriteLine("Phản hồi từ server: " + response);
            }

            Console.WriteLine("Đang đóng client");
            client.Close();
        }
    }
}
