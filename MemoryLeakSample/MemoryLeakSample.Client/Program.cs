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
            Console.WriteLine($"Current process id = {Process.GetCurrentProcess().Id}");

            List<MemoryLeakService.LeakServiceSoapClient> clientList = new List<LeakServiceSoapClient>();

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($" start iteration {i}..");
                Task.Delay(1000).Wait();

                MemoryLeakService.LeakServiceSoapClient client = new LeakServiceSoapClient();

                clientList.Add(client);

                 var processId = client.SendEmail();
                Console.WriteLine($"Service processId: {processId}");
                Console.WriteLine($" finish iteration {i}..");
            }



        }
    }
}
