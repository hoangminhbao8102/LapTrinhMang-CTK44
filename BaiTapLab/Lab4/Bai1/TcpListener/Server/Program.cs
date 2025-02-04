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
            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Đang chờ kết nối từ client...");

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Kết nối thành công với client");

            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.ASCII.GetBytes("Hello Client");
            stream.Write(buffer, 0, buffer.Length);

            while (true)
            {
                try
                {
                    buffer = new byte[1024];
                    int byteCount = stream.Read(buffer, 0, buffer.Length);
                    string request = Encoding.ASCII.GetString(buffer, 0, byteCount);

                    if (request.ToLower() == "exit")
                    {
                        Console.WriteLine("Client đã ngắt kết nối.");
                        break;
                    }

                    Console.WriteLine("Client: " + request);

                    string response = "Server nhận được: " + request;
                    buffer = Encoding.ASCII.GetBytes(response);
                    stream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                    break;
                }
            }

            client.Close();
            server.Stop();
        }
    }
}
