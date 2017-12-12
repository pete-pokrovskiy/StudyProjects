using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlend.Console.MiltipleTasksErrorHandling
{
    public class WorkUnit
    {
        public void Work(int index, int ms)
        {
            System.Console.WriteLine("Work unit {0} started. Working for {1} ms", index, ms);
            Task.Delay(ms).Wait();
            System.Console.WriteLine("Work unit {0} finished", index);

        }

        public void WorkWithException(int index)
        {
            System.Console.WriteLine("Work unit {0} started", index);
            Task.Delay(1000).Wait();
            throw new Exception($"Exception in work unit {index}");
            System.Console.WriteLine("Work unit {0} finished", index);


        }

    }
}
