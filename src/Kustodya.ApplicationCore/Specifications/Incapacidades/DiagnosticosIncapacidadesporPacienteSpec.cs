using Kustodya.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Kustodya.ApplicationCore.Helpers;
using System.Linq;

namespace Kustodya.ApplicationCore.Specifications.Incapacidades
{
    class DiagnosticosIncapacidadesporPacienteSpec : BaseSpec<TblDiagnosticosIncapacidades>
    {
        public DiagnosticosIncapacidadesporPacienteSpec(Expression<Func<TblDiagnosticosIncapacidades, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public DiagnosticosIncapacidadesporPacienteSpec(int iIDPaciente, string busqueda, int? skip, int? take)
                : this(u => ((busqueda != "" ? u.TblCie10DiagnosticoIncapacidad.Where(c=>c.IIdcie10Navigation.TCie10.ToLower() == busqueda.ToLower()).Count() > 0 : true) ||
                (busqueda != "" ? u.TblCie10DiagnosticoIncapacidad.Where(c => c.IIdcie10Navigation.TDescripcion.ToLower().Contains(busqueda.ToLower())).Count() > 0 : true) ||
                (busqueda != "" ? u.TCodigoCorto.ToLower() == busqueda.ToLower() : true)) &&
                u.IIdpaciente == iIDPaciente, skip, take)
        {
            //AddInclude(c => c.TblCie10DiagnosticoIncapacidad);
            AddIncludes(i => i.Include(c => c.TblCie10DiagnosticoIncapacidad)
                .ThenInclude(c => c.IIdcie10Navigation));
        }
    }
}
