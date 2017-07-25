using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlend.Console.MiltipleTasksErrorHandling
{
    public class WorkUnitReturnValue
    {
        public string Work(int index, int ms)
        {
            System.Console.WriteLine("[WorkUnitReturnValue] Work unit {0} started. Working for {1} ms", index, ms);
            Task.Delay(ms).Wait();

            if (index == 3 || index == 5)
                throw new Exception($"Terrible Exception for index {index}");

            System.Console.WriteLine("[WorkUnitReturnValue] Work unit {0} finished", index);
            return $"Task {index} result";
        }

    }
}
