using System;

namespace KendoNG.AspMvcWeb.ViewModels
{
    public class ActionItemViewModel
    {
        public string ActivityCode { get; set; }
        public string ActivityName { get; set; }
        public string ResourceName { get; set; }
        public string ResourceUniqueName { get; set; }
        public string TimesheetLink { get; set; }
        public ActionItemStatusViewModel OldStatus { get; set; }
        public ActionItemStatusViewModel NewStatus { get; set; }
        public DateTime PeriodBegin { get; set; }
        public DateTime PeriodEnd { get; set; }
        public decimal ActualsSum { get; set; }
        public decimal PlanSum { get; set; }
        public decimal Variance { get; set; }
        public bool HasTaskComments { get; set; }
        public bool HasTimesheetComments { get; set; }
    }

    public class ActionItemStatusViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}