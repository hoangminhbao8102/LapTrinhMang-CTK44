using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class Program
    {
        static void GetHostInfo(string host)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(host);
                //Display host name
                Console.WriteLine("Tên miền: " + hostInfo.HostName);
                //Display list of IP address
                Console.Write("Địa chỉ IP:");
                foreach (IPAddress ipaddr in hostInfo.AddressList)
                {
                    Console.Write(ipaddr.ToString() + " ");
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Không phân giải được tên miền:" + host + "\n");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            foreach (String arg in args)
            {
                Console.WriteLine("Phân giải tên miền:" + arg);
                GetHostInfo(arg);
            }
            Console.ReadKey();
        }
    }
}
