using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
            TcpListener server = new TcpListener(IPAddress.Any, 9050);
            server.Start();
            TcpClient client = server.AcceptTcpClient();
            NetworkStream ns = client.GetStream();

            byte[] size = new byte[2];
            int recv = ns.Read(size, 0, 2);
            int packsize = BitConverter.ToInt16(size, 0);
            Console.WriteLine("Kích thước gói tin = {0}", packsize);
            recv = ns.Read(size, 0, packsize);
            Employee emp1 = new Employee(data);
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

            ns.Close();
            client.Close();
            server.Stop();
        }
    }
}
