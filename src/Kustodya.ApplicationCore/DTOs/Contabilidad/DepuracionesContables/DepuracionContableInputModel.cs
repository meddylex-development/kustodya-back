using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Services.DepuracionesContables;

namespace Kustodya.ApplicationCore.DTOs.DepuracionesContables
{
    public class DepuracionContableInputModel : DTOBase
    {
        public string ClaseDocumento { get; set; }
        public string DescripcionFicha { get; set; }
        public int Folios { get; set; }
        public string SituacionEncontrada { get; set; }
        public string DisposicionesLegales { get; set; }
        public string AccionesRealizadas { get; set; }
        public string Recomendaciones { get; set; }
        public string Anexos { get; set; }
        public DepuracionContable.EstadoRevisor? EstadoRevisor { get; set; }
        public string NotaRevisor { get; set; }
    }
}