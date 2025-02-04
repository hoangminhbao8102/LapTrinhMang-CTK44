using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                throw new ArgumentException("Parameter(s): <Server> <Port> <Message>");
            }

            string server = args[0]; // Server IP address
            int servPort = Int32.Parse(args[1]); // Server port
            string message = args[2]; // Message to send

            try
            {
                // Create a TCP socket
                TcpClient client = new TcpClient(server, servPort);

                NetworkStream netStream = client.GetStream();

                // Convert message to byte array
                byte[] byteBuffer = Encoding.ASCII.GetBytes(message);

                // Send the message to the server
                netStream.Write(byteBuffer, 0, byteBuffer.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the response from the server
                int totalBytesReceived = 0;
                int bytesReceived = 0;
                byte[] rcvBuffer = new byte[EchoProtocol.BUFSIZE];

                do
                {
                    if ((bytesReceived = netStream.Read(rcvBuffer, totalBytesReceived, rcvBuffer.Length - totalBytesReceived)) == 0)
                    {
                        Console.WriteLine("Connection closed prematurely.");
                        break;
                    }
                    totalBytesReceived += bytesReceived;
                } while (totalBytesReceived < message.Length);

                Console.WriteLine("Received: {0}", Encoding.ASCII.GetString(rcvBuffer, 0, totalBytesReceived));

                // Close the stream and the socket
                netStream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
