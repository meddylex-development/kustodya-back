using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.Administracion;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications
{
    public class UsuarioPorEntidadyNombreSpec : BaseSpec<TblUsuarios>
    {
        public UsuarioPorEntidadyNombreSpec(Expression<Func<TblUsuarios, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public UsuarioPorEntidadyNombreSpec(int entidadId, string busqueda, int? skip, int? take)
                : this(u => u.Entidades.Where(c=>c.EntidadId == entidadId).Count() > 0 && (u.TPrimerNombre.ToLower() +
                (u.TSegundoNombre == null ? " " : (u.TSegundoNombre.Length == 0 ? " " : " " + u.TSegundoNombre.ToLower() + " ")) +
                u.TPrimerApellido.ToLower() +
                (u.TSegundoApellido== null ? " " : (u.TSegundoApellido.Length == 0 ? " " : " " + u.TSegundoApellido.ToLower()))).Contains(busqueda) ||
                u.TIdnumDoc.ToLower() == busqueda.ToLower(), skip, take)
        {
            AddInclude(c => c.Entidades);
            ApplyOrderByDescending(c => c.DtFechaCreacion);
        }
    }
}
