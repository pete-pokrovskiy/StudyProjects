using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncTasksTest test = new AsyncTasksTest();

            test.RunTasksInCycle();
            CL.Log("right after calling RunTasksInCycle");
            System.Console.ReadLine();

        }
    }
}
