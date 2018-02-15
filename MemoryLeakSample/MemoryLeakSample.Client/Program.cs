using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MemoryLeakSample.Client.MemoryLeakService;

namespace MemoryLeakSample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestLongRequests();
            Console.WriteLine("Start processing..");
            SendMultipleEmails();
            Console.ReadKey();
        }

        static void SendMultipleEmails()
        {
            var taskList = new List<Task>();

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.WriteLine($"Current iteration: {i}.{j}");
                    var task = Task.Factory.StartNew(() =>
                    {

                        Local_MemoryLeakSample.LeakServiceSoapClient client =
                            new Local_MemoryLeakSample.LeakServiceSoapClient();
                        client.SendEmail();

                    });
                    taskList.Add(task);
                }

                Thread.Sleep(i * 1000);
            
            }

            Task.WhenAll(taskList);
        }


        static void TestLongRequests()
        {
            var taskList = new List<Task>();

            for (int i = 0; i < 1000; i ++)
            {
                var task = Task.Factory.StartNew(() =>
                {

                    Local_MemoryLeakSample.LeakServiceSoapClient client =
                        new Local_MemoryLeakSample.LeakServiceSoapClient();
                    client.LongRequest();

                });

                Thread.Sleep(i * 1000);

                taskList.Add(task);


            }

            Task.WhenAll(taskList);

        }

    }
}
