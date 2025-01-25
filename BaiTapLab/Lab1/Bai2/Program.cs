using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Thông tin giao thức IP của local host:");
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties ipProps = ni.GetIPProperties();

                    foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Console.WriteLine("Địa chỉ IP: " + ip.Address);
                            Console.WriteLine("Subnet Mask: " + ip.IPv4Mask);
                        }
                    }

                    foreach (GatewayIPAddressInformation gateway in ipProps.GatewayAddresses)
                    {
                        Console.WriteLine("Default Gateway: " + gateway.Address);
                    }
                    Console.WriteLine(); // Dòng trống để ngăn cách thông tin của các interface
                }
            }
        }
    }
}
