using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bai2
{
    class FileLogger : ILogger
    {
        private static Mutex mutex = new Mutex();
        private StreamWriter output;

        public FileLogger(String filename)
        {
            // Create log file
            output = new StreamWriter(filename);
        }

        public void WriteEntry(ArrayList entry)
        {
            mutex.WaitOne();
            IEnumerator line = entry.GetEnumerator();
            while (line.MoveNext())
            {
                output.WriteLine(line.Current);
            }
            output.Flush();
            mutex.ReleaseMutex();
        }

        public void WriteEntry(String entry)
        {
            mutex.WaitOne();
            output.WriteLine(entry);
            output.WriteLine();
            output.Flush();
            mutex.ReleaseMutex();
        }
    }
}
