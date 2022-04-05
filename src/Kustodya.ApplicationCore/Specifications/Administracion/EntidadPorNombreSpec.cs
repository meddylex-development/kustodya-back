using Kustodya.ApplicationCore.Entities.Administracion;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Administracion
{
    public class EntidadPorNombreSpec : BaseSpec<Entidad>
    {
        public EntidadPorNombreSpec(Expression<Func<Entidad, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public EntidadPorNombreSpec(string busqueda, int? skip, int? take)
                : this(u => u.Activo == true && ((u.PrimerNombre == null ? " " : (u.PrimerNombre.Length == 0 ? " " : " " + u.PrimerNombre.ToLower() + " ")) +
                (u.SegundoNombre == null ? " " : (u.SegundoNombre.Length == 0 ? " " : " " + u.SegundoNombre.ToLower() + " ")) +
                (u.PrimerApellido == null ? " " : (u.PrimerApellido.Length == 0 ? " " : " " + u.PrimerApellido.ToLower() + " ")) +
                (u.SegundoApellido == null ? " " : (u.SegundoApellido.Length == 0 ? " " : " " + u.SegundoApellido.ToLower()))).Contains(busqueda) ||
                u.NumeroId.ToLower() == busqueda.ToLower() || (u.RazonSocial != null ? u.RazonSocial.Contains(busqueda) : false), skip, take)
        {
            AddInclude(c => c.Clientes);
            ApplyOrderByDescending(c => c.FechaCreacion);
        }
    }
}
