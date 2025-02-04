using System;
using System.Collections.Generic;
using System.Linq;
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

            while (true)
            {
                Employee emp1 = new Employee();

                Console.Write("Nhập mã nhân viên: ");
                emp1.EmployeeID = int.Parse(Console.ReadLine());

                Console.Write("Nhập họ: ");
                emp1.LastName = Console.ReadLine();

                Console.Write("Nhập tên: ");
                emp1.FirstName = Console.ReadLine();

                Console.Write("Nhập số năm công tác: ");
                emp1.YearsService = int.Parse(Console.ReadLine());

                Console.Write("Nhập lương: ");
                emp1.Salary = double.Parse(Console.ReadLine());

                TcpClient client;
                try
                {
                    client = new TcpClient("127.0.0.1", 9050);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Không kết nối được với server");
                    return;
                }

                NetworkStream ns = client.GetStream();
                byte[] data = emp1.GetBytes();
                int size = emp1.size;
                byte[] packsize = new byte[2];
                Console.WriteLine("Kích thước gói tin = {0}", size);
                packsize = BitConverter.GetBytes(size);
                ns.Write(packsize, 0, 2);
                ns.Write(data, 0, size);
                ns.Flush();

                ns.Close();
                client.Close();

                Console.Write("Bạn có muốn tiếp tục không (có/không)? ");
                string answer = Console.ReadLine().ToLower();
                if (answer == "không")
                {
                    break;
                }
            }
        }
    }
}
