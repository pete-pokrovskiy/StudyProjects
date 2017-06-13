using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoNG.AspMvcWeb.ViewModels;

namespace KendoNG.AspMvcWeb.Controllers
{
    public class GridController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetActionItems()
        {
            var viewModels = new List<ActionItemViewModel>
            {
                new ActionItemViewModel()
                {
                    ActivityName = "Тестовая активность 1",
                    ActivityCode = "proj1",
                    ResourceName = "Иванов Иван",
                    ResourceUniqueName = "iivanov",
                    OldStatus = 1,
                    NewStatus = 1,
                    TimesheetLink = "www.google.com",
                    PeriodBegin = DateTime.Now.AddDays(-5),
                    PeriodEnd = DateTime.Now.AddDays(2),
                    ActualsSum = 10,
                    PlanSum = 5,
                    Variance = (10 - 5),
                    HasTaskComments = false,
                    HasTimesheetComments = false
                },
                new ActionItemViewModel()
                {
                    ActivityName = "Тестовая активность 2",
                    ActivityCode = "proj2",
                    ResourceName = "Иванов Иван",
                    ResourceUniqueName = "iivanov",
                    OldStatus = 1,
                    NewStatus = 1,
                    TimesheetLink = "www.google.com",
                    PeriodBegin = DateTime.Now.AddDays(-5),
                    PeriodEnd = DateTime.Now.AddDays(2),
                    ActualsSum = 10,
                    PlanSum = 5,
                    Variance = (10 - 5),
                    HasTaskComments = false,
                    HasTimesheetComments = false
                },
                new ActionItemViewModel()
                {
                    ActivityName = "Тестовая активность 1",
                    ActivityCode = "proj1",
                    ResourceName = "Федоров Федор",
                    ResourceUniqueName = "ffedorov",
                    OldStatus = 2,
                    NewStatus = 1,
                    TimesheetLink = "www.google.com",
                    PeriodBegin = DateTime.Now.AddDays(-5),
                    PeriodEnd = DateTime.Now.AddDays(2),
                    ActualsSum = 10,
                    PlanSum = 5,
                    Variance = (10 - 5),
                    HasTaskComments = false,
                    HasTimesheetComments = false
                },
                new ActionItemViewModel()
                {
                    ActivityName = "Тестовая активность 2",
                    ActivityCode = "proj2",
                    ResourceName = "Федоров Федор",
                    ResourceUniqueName = "ffedorov",
                    OldStatus = 2,
                    NewStatus = 1,
                    TimesheetLink = "www.google.com",
                    PeriodBegin = DateTime.Now.AddDays(-5),
                    PeriodEnd = DateTime.Now.AddDays(2),
                    ActualsSum = 10,
                    PlanSum = 5,
                    Variance = (10 - 5),
                    HasTaskComments = false,
                    HasTimesheetComments = false
                },
                new ActionItemViewModel()
                {
                    ActivityName = "Тестовая активность 1",
                    ActivityCode = "proj3",
                    ResourceName = "Федоров Федор",
                    ResourceUniqueName = "ffedorov",
                    NewStatus = 1,
                    TimesheetLink = "www.google.com",
                    PeriodBegin = DateTime.Now.AddDays(-5),
                    PeriodEnd = DateTime.Now.AddDays(2),
                    ActualsSum = 10,
                    PlanSum = 5,
                    Variance = (10 - 5),
                    HasTaskComments = false,
                    HasTimesheetComments = false
                },
                new ActionItemViewModel()
                {
                    ActivityName = "Тестовая активность 2",
                    ActivityCode = "proj4",
                    ResourceName = "Федоров Федор",
                    ResourceUniqueName = "ffedorov",
                    OldStatus = 1,
                    NewStatus = 1,
                    TimesheetLink = "www.google.com",
                    PeriodBegin = DateTime.Now.AddDays(-5),
                    PeriodEnd = DateTime.Now.AddDays(2),
                    ActualsSum = 10,
                    PlanSum = 5,
                    Variance = (10 - 5),
                    HasTaskComments = false,
                    HasTimesheetComments = false
                },
            };

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }
    }
}