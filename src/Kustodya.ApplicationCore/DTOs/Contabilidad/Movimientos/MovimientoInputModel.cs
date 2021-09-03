using Kustodya.ApplicationCore.DTOs;
using System;

namespace Kustodya.ApplicationCore.DTOs.Contabilidades
{
    public class MovimientoInputModel : DTOBase
    {
        public long CodigoContable { get; set; }
        public string DescripcionMovimiento { get; set; }
        public Guid CentroCostoId { get; set; }
        public string NitTercero { get; set; }
        public int? Debito { get; set; }
        public int? Credito { get; set; }
        public string Referencia { get; set; }
        public long NumComprobanteCierre { get; set; }
        public string ReferenciacionSoportes { get; set; }
        public int UsuarioCreacion { get; set; }
        public int EntidadId { get; set; }
        public Guid TipoAjusteId { get; set; }
    }
}