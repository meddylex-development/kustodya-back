using Kustodya.ApplicationCore.Dtos.General;
using Kustodya.ApplicationCore.Dtos.Multivalores;
using Kustodya.ApplicationCore.Dtos.Negocio;
using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Dtos.Incapacidades
{
    public class DiagnosticoIncapacidadModel
    {
        public DiagnosticoIncapacidadModel()
        {
            TipoAtencion = new TipoAtencionModel();
            TipoEmision = new TipoEmisionModel();
        }

        public bool BProrroga { get; set; }
        public bool BSOAT { get; set; }
        public List<CIE10Model> Cie10 { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public DateTime DtFechaFin { get; set; }
        public bool EsTranscripcion { get; set; }
        public DateTime FechaEmisionIncapacidad { get; set; }
        public int? IDiasAcumuladosPorroga { get; set; }
        public int IDiasIncapacidad { get; set; }
        public long IIddiagnosticoIncapacidad { get; set; }
        public long IIdips { get; set; }
        public long IIdEps { get; set; }
        public int IIdpaciente { get; set; }
        public int IIdUsuarioCreador { get; set; }
        public UbicacionModel LugarExpedicion { get; set; }
        public string NumeroIncapacidadIPSTranscripcion { get; set; }
        public OrigenIncapacidadModel OrigenCalificadoIncapacidad { get; set; }
        public OrigenIncapacidadModel PresuntoOrigenIncapacidad { get; set; }
        public string TCodigoCorto { get; set; }
        public string TDescripcionSintomatologica { get; set; }
        public TipoAtencionModel TipoAtencion { get; set; }
        public TipoEmisionModel TipoEmision { get; set; }
        public string TLugar { get; set; }
        public string TLugarExpedicion { get; set; }
        public string TModo { get; set; }
        public string TTiempo { get; set; }
        public Guid? UiCodigoDiagnostico { get; set; }
        public virtual EpsModel Eps { get; set; }
        public virtual IPSModel Ips { get; set; }
    }
}