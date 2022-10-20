using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Rethus
{
    public class TareasporCargue : BaseSpec<tblRethusCargues>
    {
        public TareasporCargue(Expression<Func<tblRethusCargues, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }

        public TareasporCargue(int? skip, int? take)
                : this(u => true, skip, take)
        {
            ApplyOrderByDescending(c => c.dtFechaCreacion);
        }
    }
}
