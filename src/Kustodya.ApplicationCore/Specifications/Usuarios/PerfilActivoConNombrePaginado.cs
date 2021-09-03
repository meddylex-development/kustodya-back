using System;
using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications
{
    public class PerfilActivoConNombrePaginado : BaseSpec<TblPerfiles>
    {
        public PerfilActivoConNombrePaginado(string nombre, int pagina = 0) : base(p => (string.IsNullOrWhiteSpace(nombre) || p.TDescripcion.Contains(nombre)) && p.BActivo == true)
        {
            pagina = Math.Clamp(pagina, 1, int.MaxValue);
            ApplyPaging((pagina - 1) * 10, 10);
        }
    }
}