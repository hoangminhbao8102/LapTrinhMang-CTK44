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
            TcpClient client = new TcpClient();

            try
            {
                Console.WriteLine("Đang kết nối với server...");
                client.Connect(IPAddress.Loopback, 5000);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Không thể kết nối đến server");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            if (client.Connected)
            {
                Console.WriteLine("Kết nối thành công với server...");
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int byteCount = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, byteCount);
                Console.WriteLine(response);

                while (true)
                {
                    string request = Console.ReadLine();

                    if (request.ToLower() == "exit")
                    {
                        Console.WriteLine("Đang ngắt kết nối...");
                        break;
                    }

                    buffer = Encoding.ASCII.GetBytes(request);
                    stream.Write(buffer, 0, buffer.Length);

                    buffer = new byte[1024];
                    byteCount = stream.Read(buffer, 0, buffer.Length);
                    response = Encoding.ASCII.GetString(buffer, 0, byteCount);
                    Console.WriteLine(response);
                }

                client.Close();
                Console.WriteLine("Client đã ngắt kết nối.");
            }

            Console.ReadKey();
        }
    }
}
