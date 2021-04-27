using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study.Console
{
    class CL
    {
        public static void Log(string info)
        {
            if (string.IsNullOrEmpty(info))
            {
                return;
            }
                

            System.Console.WriteLine($"[Time = {DateTime.Now}, ThreadId = {Thread.CurrentThread.ManagedThreadId}]");
            System.Console.WriteLine(info);
            System.Console.WriteLine();

        }

    }
}
