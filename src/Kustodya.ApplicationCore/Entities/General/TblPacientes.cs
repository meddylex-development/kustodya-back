using Kustodya.ApplicationCore.Entities.Concepto;
using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPacientes
    {
        public TblPacientes()
        {
            TblDiagnosticosIncapacidades = new HashSet<TblDiagnosticosIncapacidades>();
        }

        public int IIdpaciente { get; set; }
        public long IIdeps { get; set; }
        public long IIdafp { get; set; }
        public long IIdarl { get; set; }
        public int IIdempresaPaciente { get; set; }
        public long IIdtipoDoc { get; set; }
        public long IIdgenero { get; set; }
        public string TNumeroDocumento { get; set; }
        public string TPrimerNombre { get; set; }
        public string TSegundoNombre { get; set; }
        public string TPrimerApellido { get; set; }
        public string TSegundoApellido { get; set; }
        public string TDireccion { get; set; }
        public string TTelefono { get; set; }
        public string TEmail { get; set; }
        public DateTime? DtFechaNacimiento { get; set; }
        public short IIddane { get; set; }
        public byte? IIdtipoAfiliacion { get; set; }
        public long? IIdempresa { get; set; }
        public byte? IIdregimenAfiliacion { get; set; }
        public int? IEdad { get; set; }
        public short IIdciuo08 { get; set; }
        public byte? IIdestadoAfiliacion { get; set; }

        public virtual TblAfp IIdafpNavigation { get; set; }
        public virtual TblArls IIdarlNavigation { get; set; }
        public virtual TblCiuo08 IIdciuo08Navigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEps IIdepsNavigation { get; set; }
        public virtual TblEstadoAfiliacion IIdestadoAfiliacionNavigation { get; set; }
        public virtual TblMultivalores IIdgeneroNavigation { get; set; }
        public virtual TblRegimenAfiliacion IIdregimenAfiliacionNavigation { get; set; }
        public virtual TblTipoAfiliacion IIdtipoAfiliacionNavigation { get; set; }
        public virtual TblMultivalores IIdtipoDocNavigation { get; set; }
        public virtual ICollection<TblDiagnosticosIncapacidades> TblDiagnosticosIncapacidades { get; set; }
        public virtual ICollection<PacientesPorEmitir> PacientesPorEmtitir { get; set; }

        public string ObtenerNombre()
        {
            return TPrimerNombre +
                (TSegundoNombre == null ? " " : (TSegundoNombre.Length == 0 ? " " : " " + TSegundoNombre + " ")) +
                TPrimerApellido +
                (TSegundoApellido == null ? " " : (TSegundoApellido.Length == 0 ? " " : " " + TSegundoApellido));
        }

    }
}
