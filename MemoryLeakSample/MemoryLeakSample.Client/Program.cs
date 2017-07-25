using System;
using System.Collections.Generic;
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

            for (int i = 0; i < 20; i++)
            {

                Task.Delay(1000).Wait();

                MemoryLeakService.LeakServiceSoapClient client = new LeakServiceSoapClient();

                 string result  = client.HelloWorld();

                Console.WriteLine($"result {i}: {result} ");
            }



        }
    }
}
