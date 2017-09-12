using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryLeakSample.NotificationViewModels
{
    public class SMNotificationViewModel
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectUrl { get; set; }
        public string TaskId { get; set; }
        public DateTime EffortDate { get; set; }
        public string ResourceId { get; set; }
        public string ResourceName { get; set; }
        public int TaskActualsCount { get; set; }
        public string RequisitionNo { get; set; }
        public string EffortAmount { get; set; }
        public string TaskUrl { get; set; }
        public string TaskName { get; set; }

    }
}