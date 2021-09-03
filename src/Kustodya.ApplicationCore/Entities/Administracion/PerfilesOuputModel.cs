using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Dtos
{
    public class PerfilesOuputModel
    {
        public IReadOnlyList<PerfilOutputModel> Perfiles { get; set; }
        public PaginacionModel Paginacion { get; set; }
        public bool FiltroDeNombreAplicado { get; set; }
    }
}