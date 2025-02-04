using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            RetryUdpClient client = new RetryUdpClient("127.0.0.1", 5000);
            client.Run();
        }
    }

    class RetryUdpClient
    {
        private Socket clientSocket;
        private EndPoint serverEndPoint;
        private byte[] data;

        public RetryUdpClient(string serverIP, int serverPort)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
            clientSocket.Connect(serverEndPoint);
            data = new byte[1024];

            // Thiết lập timeout
            int sockopt = (int)clientSocket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
            Console.WriteLine("Giá trị timeout mặc định: {0}", sockopt);
            clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
            sockopt = (int)clientSocket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
            Console.WriteLine("Giá trị timeout mới: {0}", sockopt);
        }

        private int SndRcvData(Socket s, byte[] message, EndPoint rmtdevice)
        {
            int recv;
            int retry = 0;
            while (true)
            {
                Console.WriteLine("Truyền lại lần thứ: #{0}", retry);
                try
                {
                    s.SendTo(message, message.Length, SocketFlags.None, rmtdevice);
                    data = new byte[1024];
                    recv = s.ReceiveFrom(data, ref rmtdevice);
                }
                catch (SocketException)
                {
                    recv = 0;
                }
                if (recv > 0)
                {
                    return recv;
                }
                else
                {
                    retry++;
                    if (retry > 4)
                    {
                        return 0;
                    }
                }
            }
        }

        public void Run()
        {
            string input, stringData;
            int recv;
            string welcome = "Hello Server";
            recv = SndRcvData(clientSocket, Encoding.ASCII.GetBytes(welcome), serverEndPoint);
            if (recv > 0)
            {
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);
            }
            else
            {
                Console.WriteLine("Không thể liên lạc với thiết bị ở xa");
                return;
            }
            while (true)
            {
                Console.Write("Nhập thông điệp gửi tới server: ");
                input = Console.ReadLine();
                if (input.Trim().ToLower() == "exit" || input.Trim().ToLower() == "exit all")
                {
                    SndRcvData(clientSocket, Encoding.ASCII.GetBytes(input), serverEndPoint);
                    break;
                }
                recv = SndRcvData(clientSocket, Encoding.ASCII.GetBytes(input), serverEndPoint);
                if (recv > 0)
                {
                    stringData = Encoding.ASCII.GetString(data, 0, recv);
                    Console.WriteLine(stringData);
                }
                else
                {
                    Console.WriteLine("Không nhận được câu trả lời");
                }
            }
            Console.WriteLine("Đang đóng client");
            clientSocket.Close();
        }
    }
}
