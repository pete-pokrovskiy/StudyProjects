using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

namespace AsmxMemoryLeakTest
{
    /// <summary>
    /// Summary description for HungyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HungyService : System.Web.Services.WebService
    {
      public static XDocument Settings { get; set; }

        public HungyService()
        {
            Settings = XDocument.Load(HttpContext.Current.Server.MapPath("~/") + "Settings.Xml");
        }

        [WebMethod]
        public string GetSettings()
        {
            return Settings.ToString();
        }
    }
}
