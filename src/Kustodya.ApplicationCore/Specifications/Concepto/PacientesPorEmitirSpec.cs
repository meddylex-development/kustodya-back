using Kustodya.ApplicationCore.Entities.Concepto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Concepto
{
    public class PacientesPorEmitirSpec : BaseSpec<PacientesPorEmitir>
    {
        public PacientesPorEmitirSpec(Expression<Func<PacientesPorEmitir, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public PacientesPorEmitirSpec(string busqueda, int? skip, int? take, PacientesPorEmitir.EstadoConcepto? estadoConcepto)
                : this(u => (estadoConcepto != null ? u.Estado == estadoConcepto : true) && 
                ((busqueda != "" ? u.concepto.CodigoCorto.ToLower() == busqueda.ToLower() : true) ||
                (busqueda != "" ? (u.Paciente.TPrimerNombre.ToLower() +
                (u.Paciente.TSegundoNombre == null ? " " : (u.Paciente.TSegundoNombre.Length == 0 ? " " : " " + u.Paciente.TSegundoNombre.ToLower() + " ")) +
                u.Paciente.TPrimerApellido.ToLower() +
                (u.Paciente.TSegundoApellido == null ? " " : (u.Paciente.TSegundoApellido.Length == 0 ? " " : " " + u.Paciente.TSegundoApellido.ToLower()))).Contains(busqueda) : true ) ||
                (busqueda != "" ? u.Paciente.TNumeroDocumento.ToLower() == busqueda.ToLower() : true)), skip, take)
        {
            AddInclude(c => c.Paciente);
            AddInclude(c => c.concepto);
            ApplyOrderBy(c => c.FechaAsignacion);
        }

    }
}
