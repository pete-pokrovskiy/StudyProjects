using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Console
{
    class AsyncTasksTest
    {

        public async Task RunTasksInCycle()
        {
            try
            {


                List<Task> tasks = new List<Task>();

                CL.Log("before cycle");
                for (int i = 0; i < 10; i++)
                {
                    var task = RunModTwoTaskAsync(i);
                    tasks.Add(task);
                }
                CL.Log("after cycle, starting await");

                await Task.WhenAll(tasks);

                CL.Log("after await");
            }
            catch (Exception ex)
            {
                
            }
        }


        public Task<int> RunModTwoTaskAsync(int num)
        {
            Task<int> modTwoTask = (Task<int>) Task.Run(async () =>
            {
                await Task.Delay(num%2*1000);

                if(num == 5 || num == 3)
                    throw new Exception($"Terrible exception occurred for num = {num}");

                CL.Log($"passed value {num}");
                return num%2;
            });

            return modTwoTask;
        }


    }
}
