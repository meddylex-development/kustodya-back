using System;
using System.Collections.Generic;
using Kustodya.ApplicationCore.Dtos;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class ContabilidadOutputModel
    {   
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool EsContabilidadPorDefecto { get; set; }
        public string Debito { get; set; }
        public string Credito { get; set; }
        public string TipoContabilidad { get; set; }
        public string ReferenciaMovimientoPorDefecto { get; set; }
        public string DescripcionMovimientoPorDefecto { get; set; }
        public string ClaseDocumentoPorDefecto { get; set; }
        public string TipoAjustePorDefecto { get; set; }

    }

    public class ContabilidadesOutputModel
    {
        public IReadOnlyList<ContabilidadOutputModel> Contabilidades { get; set; }
        public PaginacionModel Paginacion { get; set; }
        public bool FiltroDeNombreAplicado { get; set; }

    }
}