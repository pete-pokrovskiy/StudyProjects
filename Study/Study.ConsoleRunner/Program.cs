using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Xml;

namespace Study.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //PlayWithAsyncTask()

            //PlayWithXmlDocument();

            //DateTimeTests.TestDateTimeKind();

            DateTimeTests.GoThroughDateTimeRange();
            
            System.Console.ReadLine();

        }

        static void PlayWithAsyncTask()
        {
            AsyncTasksTest test = new AsyncTasksTest();

            test.RunTasksInCycle();
            CL.Log("right after calling RunTasksInCycle");
        }

        static void PlayWithXmlDocument()
        {
            XmlDocProcessor xdocProcessor = new XmlDocProcessor();
            System.Console.WriteLine(xdocProcessor.CreateXmlDocumentWithDeclaration().OuterXml);

        }

    }
}
