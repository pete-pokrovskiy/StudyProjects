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

                    tasks.Add(task);
                }

                try
                {
                    Task.WaitAll(tasks.ToArray());
                }
                catch (Exception ex)
                {
                    //в этом месте получаем aggregate exception, в inner exception-aх которого все исключения, выброшенные тасками

                    foreach (var task in tasks)
                    {
                        System.Console.WriteLine("{0}  {1}", task.Status, task.IsFaulted);
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
                //if (!task.IsFaulted)
                try
                {
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
