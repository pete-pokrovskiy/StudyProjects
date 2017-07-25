using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using ClarityTestappLoader.Console.SilverlightService;

namespace ClarityTestappLoader.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 100; i++)
            {

                SilverLightServicesSoapClient client = new SilverLightServicesSoapClient();

                System.Console.WriteLine("GetUserRights(ppokrovskiy");
                var rightsResult = client.GetUserRights("ppokrovskiy");

                System.Threading.Tasks.Task.Delay(2000).Wait();

                System.Console.WriteLine("GetCurrentResourceCode");

                var resourceCode = client.GetCurrentResourceCode();

                System.Threading.Tasks.Task.Delay(2000).Wait();


                System.Console.WriteLine("GetObjectID(PROJ0000062368, project)");

                var objectid = client.GetObjectID("PROJ0000062368", "project");

                System.Threading.Tasks.Task.Delay(2000).Wait();

                System.Console.WriteLine("GetTimesheetActionItems(lkhoroshilova)");

                var actionItems = client.GetTimesheetActionItems("lkhoroshilova");
                System.Threading.Tasks.Task.Delay(2000).Wait();

                System.Console.WriteLine("GetTimesheetActionItems(vmatveyko)");
                var actionItems2 = client.GetTimesheetActionItems("vmatveyko");

                System.Threading.Tasks.Task.Delay(2000).Wait();

            }

        }
    }
}
