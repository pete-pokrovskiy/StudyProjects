using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlend
{
    class Program
    {
        static void Main(string[] args)
        {
            string testStr = "<img src=\"data: image / super; base64,iVBORw0KGgoAAAANSUh";

            testStr = testStr.Replace(" ", "");

            Console.WriteLine(testStr.Substring((testStr.IndexOf('/') + 1), testStr.IndexOf(';') - testStr.IndexOf('/') - 1));
        }
    }
}
