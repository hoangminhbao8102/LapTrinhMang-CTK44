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

                    // Thực hiện phép tính
                    string result = PerformCalculation(str);

                    // Gửi kết quả trả lời cho client
                    buff = Encoding.ASCII.GetBytes(result);
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

        static string PerformCalculation(string input)
        {
            try
            {
                string[] parts = input.Split(' ');
                double num1 = Convert.ToDouble(parts[0]);
                string op = parts[1];
                double num2 = Convert.ToDouble(parts[2]);
                double result = 0;

                switch (op)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        result = num1 / num2;
                        break;
                    default:
                        return "Phép tính không hợp lệ.";
                }

                return "Kết quả: " + result.ToString();
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
