using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Xml;
using MemoryLeakSample.NotificationViewModels;

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
        public void LongRequest()
        {
            Thread.Sleep(30000);   
           
        }



        [WebMethod]
        public string SendEmail()
        {
            SmtpClient client = new SmtpClient("localhost", 25);

            var body = NotificationFactory.ParseTemplate(new SMNotificationViewModel
            {
                ProjectUrl = "www.google.com",
                ProjectName = Guid.NewGuid().ToString(),
                TaskUrl = "www.yandex.ru",
                TaskName = Guid.NewGuid().ToString()
            });


            MailMessage message = new MailMessage("testfrom@croc.ru", "testto@croc.ru", "Test subject", body)
            {
                IsBodyHtml = true
            };

            client.Send(message);

            return Process.GetCurrentProcess().Id.ToString();
        }
    }
}
