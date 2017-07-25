using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace MemoryLeakSample
{
    /// <summary>
    /// Summary description for LeakService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LeakService : System.Web.Services.WebService
    {

        private static readonly XmlDocument WebServiceSettings;

        static LeakService()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6) + "\\";
            

            WebServiceSettings = new XmlDocument();
            WebServiceSettings.Load(path + @"WebServiceSettings.xml");
        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
