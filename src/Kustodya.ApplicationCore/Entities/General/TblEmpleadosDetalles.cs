using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpleadosDetalles
    {
        public long Id { get; set; }
        public string OriginProgramType { get; set; }
        public string AchievedTitle { get; set; }
        public string Ocupation { get; set; }
        public DateTime AuthorizedTo { get; set; }
        public string ReportingEntity { get; set; }
        public long EmployeeId { get; set; }

        public virtual TblEmpleados Employee { get; set; }
    }
}
