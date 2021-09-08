using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Rethus
{
    public class tblRethusTasks
    {
        public int iIDTask { get; set; }
        public int iIDAllocatorUser { get; set; }
        public int iIDTaskType { get; set; }
        public int iIDPriority { get; set; }
        public int iIDTaskState { get; set; }
        public int? iIDAssignedRobot { get; set; }
        public DateTime dtAllocatedDate { get; set; }
        public DateTime? dtInitalDate { get; set; }
        public DateTime? dtEndDate { get; set; }
    }
}
