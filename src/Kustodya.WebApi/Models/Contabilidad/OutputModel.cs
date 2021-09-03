using System.Collections.Generic;
using Kustodya.ApplicationCore.Dtos;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class OutputModel<T>
    {
        public OutputModel(List<T> items, int pagina, int total)
        {
            Items = items;
            Paginacion = new PaginacionModel(total, pagina);
        }
        public IReadOnlyList<T> Items { get; set; }
        public PaginacionModel Paginacion { get; set; }
        public bool FiltroDeNombreAplicado { get; set; }

    }
}