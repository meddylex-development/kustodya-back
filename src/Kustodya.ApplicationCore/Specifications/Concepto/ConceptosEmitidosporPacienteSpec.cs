using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kustodya.ApplicationCore.Entities.Concepto;
using Kustodya.ApplicationCore.Helpers;

namespace Kustodya.ApplicationCore.Specifications.Concepto
{
    class ConceptosEmitidosporPacienteSpec : BaseSpec<ConceptoRehabilitacion>
    {
        public ConceptosEmitidosporPacienteSpec(Expression<Func<ConceptoRehabilitacion, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public ConceptosEmitidosporPacienteSpec(int iIDPaciente, string busqueda, int? skip, int? take)
                : this(u => ((busqueda != "" ? u.Diagnosticos.Where(c => c.Cie10.TDescripcion.ToLower().Contains(busqueda.ToLower())).Count() > 0 : true) ||
                (busqueda != "" ? u.Diagnosticos.Where(c=>c.Cie10.TCie10.ToLower() == busqueda.ToLower()).Count() > 0 : true) ||
                (busqueda != "" ? (u.UsuarioCreacion.TPrimerNombre.ToLower() +
                (u.UsuarioCreacion.TSegundoNombre == null ? " " : (u.UsuarioCreacion.TSegundoNombre.Length == 0 ? " " : " " + u.UsuarioCreacion.TSegundoNombre.ToLower() + " ")) +
                u.UsuarioCreacion.TPrimerApellido.ToLower() +
                (u.UsuarioCreacion.TSegundoApellido == null ? " " : (u.UsuarioCreacion.TSegundoApellido.Length == 0 ? " " : " " + u.UsuarioCreacion.TSegundoApellido.ToLower()))).Contains(busqueda.ToLower()) : true) ||
                (busqueda != "" ? u.CodigoCorto.ToLower() == busqueda.ToLower() : true)) &&
                u.PacienteId == iIDPaciente && 
                u.PacienteporEmitir.Estado == PacientesPorEmitir.EstadoConcepto.Emitido, skip, take)
        {
            AddInclude(c => c.UsuarioCreacion);
            AddIncludes(i => i.Include(c => c.Paciente)
                .ThenInclude(c => c.IIdepsNavigation));
            AddInclude(c => c.Diagnosticos);
        }
    }
}