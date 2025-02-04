using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            MyThreadClass mtc1 = new MyThreadClass("Đây là tiểu trình thứ 1");
            Thread thread1 = new Thread(new ThreadStart(mtc1.RunMyThread));
            thread1.Start();

            MyThreadClass mtc2 = new MyThreadClass("Đây là tiểu trình thứ 2");
            Thread thread2 = new Thread(new ThreadStart(mtc2.RunMyThread));
            thread2.Start();

            Console.ReadKey();
        }
    }
}
