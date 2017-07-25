using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlend.Console.MiltipleTasksErrorHandling
{
    public class TasksRunner
    {
        public void RunTasks()
        {
            Random rand = new Random();

            List<Task> tasks = new List<Task>();


            for (int i = 0; i < 8; i++)
            {
                int sec = rand.Next(1, 10);
                int currentIndex = i;

                Task task = i == 3 || i == 7
                    ? Task.Run(() => new WorkUnit().WorkWithException(currentIndex))
                    : Task.Run(() => new WorkUnit().Work(currentIndex, sec*1000));

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
        }

        public void RunTasksWithReturnValue()
        {
            Random rand = new Random();
            List<Task<string>> tasks = new List<Task<string>>();

            Dictionary<int, int> runTasksDictionary = new Dictionary<int, int>();

            try
            {
                for (int i = 0; i < 8; i++)
                {
                    int sec = rand.Next(1, 10);
                    int currentIndex = i;

                    Task<string> task = Task.Run(() =>
                    {
                        var workUnit = new WorkUnitReturnValue();
                        return workUnit.Work(currentIndex, sec*1000);
                    });

                    runTasksDictionary.Add(task.Id, currentIndex);

                    tasks.Add(task);
                }

                try
                {
                    Task.WaitAll(tasks.ToArray());
                }
                catch (Exception ex)
                {
                    //в этом месте получаем aggregate exception, в inner exception-aх которого все исключения, выброшенные тасками
                    System.Console.WriteLine();
                    System.Console.WriteLine();
                    System.Console.WriteLine("Following tasks ended up with errors:");
                    foreach (var task in tasks.Where(t => t.IsFaulted))
                    {
                        System.Console.WriteLine("Task with input parameter {0}", runTasksDictionary[task.Id]);
                        System.Console.WriteLine("Exception details: ");
                        System.Console.WriteLine(task.Exception.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("External exception");
            }


            System.Console.WriteLine();
            System.Console.WriteLine();


            foreach (var task in tasks)
            {
                //при обращении к резалту таска с ошибкой будет повторно выброшено исключение
                //поэтому либо проверять faulted или статус. либо  оборачивать в try-catch               
                try
                {
                    if (!task.IsFaulted)
                        System.Console.WriteLine(task.Result);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Getting task result exception:");
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
