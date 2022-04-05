using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Dtos.Incapacidades
{
    public class TranscripcionAIModel
    {
        public DateTime fechaNacimiento;

        public TranscripcionAIModel()
        {
            Diagnostico = new DiagnosticoIncapacidadModel();
        }
        public DiagnosticoIncapacidadModel Diagnostico { get; set; }

        #region paciente
        public string NombrePaciente {get;set;}
        public string NumeroDocumentoPaciente {get;set; }
        public string TipoDocumentoPaciente { get; set; }
        public string GeneroPaciente { get; set; }
        public string EdadPaciente { get; set; }
        #endregion

        #region eps
        public string NumeroIdentificacionEps { get; set; }
        public string NombreEps { get; set; }
        public string NumeroHabilitacionEPS { get; set; }
        #endregion

        #region ips
        public string IpsTipoIdentificacion { get; set; }
        public string IpsNumeroIdentificacion { get; set; }
        public string IpsNombre { get; set; }
        public string IpsCodigoExterno { get; set; }
        #endregion

        #region medico
        public string MedicoTipoIdentificacion { get; set; }
        public string RegistroMedico { get; set; }
        public string NombreMedico { get; set; }
        public string EspecialidadMedico { get; set; }
        #endregion

        public string IdCie10 { get; set; }
        public string DescripcionCie10 { get; set; }
        public string NumeroIncapacidad { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string CentroAtencion { get; set; }
        public ClasificacionIncapacidad ClaseIncapacidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string DiagnosticoMedico { get; set; }
        public PacienteModel Paciente { get; set; }
        public string TipoOrigen { get; set; }
        public short DiasIncapacidad { get; set; }
        public string FechaNacimientoText { get; set; }
        public string FechaDocumento { get; set; }
        public string CentroAtencionFull { get; set; }
        public string ClaseIncapacidadText { get; set; }
    }
}
