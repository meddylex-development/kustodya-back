using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Rethus
{
    public class TareasporCargue : BaseSpec<tblRethusTasks>
    {
        public TareasporCargue(Expression<Func<tblRethusTasks, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }

        public TareasporCargue(int? skip, int? take)
                : this(u => u.iIDTaskType == 2, skip, take)
        {
            ApplyOrderByDescending(c => c.iIDTask);
        }
    }
}
