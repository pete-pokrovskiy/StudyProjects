using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KendoNG.AspMvcWeb.Controllers
{
    public class TaskTreeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        //public JsonResult TestTask()
        //{
            //var task = Task.Factory.StartNew(() =>
            //{
            //    Task.Delay(10000).Wait();
            //});

            //task.
        //}
    }
}