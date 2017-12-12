using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBlend.Console.MiltipleTasksErrorHandling;

namespace TestBlend.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RunMiltipleTasks();
        }

        static void RunMiltipleTasks()
        {
            TasksRunner runner = new TasksRunner();

            //runner.RunTasks();

            try
            {
                runner.RunTasksWithReturnValue();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Root exception:");
                System.Console.WriteLine();
                System.Console.WriteLine(ex.ToString());

            }
        }
    }
}
