using System;
using System.Collections.Generic;
using System.IO;
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
            byte[] data = new byte[1024];
            UdpClient server = new UdpClient(9050);
            IPEndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                data = server.Receive(ref clientEP);
                int packsize = BitConverter.ToInt16(data, 0);
                Console.WriteLine("Kích thước gói tin = {0}", packsize);
                Employee emp1 = new Employee(data.Skip(2).ToArray());
                Console.WriteLine("emp1.EmployeeID = {0}", emp1.EmployeeID);
                Console.WriteLine("emp1.LastName = {0}", emp1.LastName);
                Console.WriteLine("emp1.FirstName = {0}", emp1.FirstName);
                Console.WriteLine("emp1.YearsService = {0}", emp1.YearsService);
                Console.WriteLine("emp1.Salary = {0}\n", emp1.Salary);

                // Ghi dữ liệu vào file .txt
                using (StreamWriter sw = new StreamWriter("employee_data.txt", true))
                {
                    sw.WriteLine("EmployeeID = {0}", emp1.EmployeeID);
                    sw.WriteLine("LastName = {0}", emp1.LastName);
                    sw.WriteLine("FirstName = {0}", emp1.FirstName);
                    sw.WriteLine("YearsService = {0}", emp1.YearsService);
                    sw.WriteLine("Salary = {0}\n", emp1.Salary);
                }
            }
        }
    }
}
