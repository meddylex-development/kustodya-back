using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblIpssEps
    {
        public long IIdipseps { get; set; }
        public long IIdips { get; set; }
        public long IIdeps { get; set; }

        public virtual TblEps IIdepsNavigation { get; set; }
        public virtual TblIps IIdipsNavigation { get; set; }
    }
}
