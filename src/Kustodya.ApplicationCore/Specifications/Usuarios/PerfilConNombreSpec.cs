using System;
using System.Linq.Expressions;
using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications
{
    public class PerfilActivoConNombre : BaseSpec<TblPerfiles>
    {
        public PerfilActivoConNombre(string nombre, int pagina = 0) : base(p => (string.IsNullOrWhiteSpace(nombre) || p.TDescripcion.Contains(nombre)) && p.BActivo == true)
        {
        }
    }
}