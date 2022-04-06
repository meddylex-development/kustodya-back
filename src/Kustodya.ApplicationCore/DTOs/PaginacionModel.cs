using System;

namespace Kustodya.ApplicationCore.Dtos
{
    public class PaginacionModel
    {
        public PaginacionModel()
        {

        }

        public PaginacionModel(int total, int paginaActual = 1, int itemsPorPagina = 10)
        {
            TotalItems = total;
            TotalPaginas = Convert.ToInt32(Math.Ceiling((decimal)total / itemsPorPagina));
            ItemsPorPagina = itemsPorPagina;

            if (paginaActual >= TotalPaginas)
                PaginaActual = TotalPaginas;
            else if (paginaActual <= 0)
                PaginaActual = 1;
            else
                PaginaActual = paginaActual;

            Anterior = Math.Clamp(paginaActual - 1,
             TotalPaginas > 0 ? 1 : 0,
             TotalPaginas);
            Siguiente = Math.Clamp(paginaActual + 1,
             TotalPaginas > 0 ? 1 : 0,
             TotalPaginas);
        }

        public int TotalItems { get; set; }
        public int ItemsPorPagina { get; set; }
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int Anterior { get; set; }
        public int Siguiente { get; set; }
    }
}