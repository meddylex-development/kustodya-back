using Kustodya.ApplicationCore.Dtos.General;
using Kustodya.ApplicationCore.Dtos.Multivalores;
using Kustodya.ApplicationCore.Dtos.Negocio;
using System;

namespace Kustodya.ApplicationCore.Dtos.Incapacidades
{
    public class PacienteModel
    {
        private PacienteModel()
        {
            Empresa = new EmpresaTercerosModel();
            Ubicacion = new UbicacionModel();
            Ocupacion = new OcupacionModel();
        }

        public ARLModel ARL { get; set; }
        public DateTime DtFechaNacimiento { get; set; }
        public EmpresaTercerosModel Empresa { get; set; }
        public EpsModel Eps { get; set; }
        public AFPModel FondoPensiones { get; set; }
        public GeneroModel Genero { get; set; }
        public short IEdad { get; set; }
        public int IIdpaciente { get; set; }
        public OcupacionModel Ocupacion { get; set; }
        public RegimenAfiliacionModel RegimenAfiliacion { get; set; }
        public string TDireccion { get; set; }
        public string TEmail { get; set; }
        public TipoAfiliacionModel TipoAfiliacion { get; set; }
        public TipoIdentificacionModel TipoDocumento { get; set; }
        public TipoPlanModel TipoPlan { get; set; }
        public string TNumeroDocumento { get; set; }
        public string TPrimerApellido { get; set; }
        public string TPrimerNombre { get; set; }
        public string TSegundoApellido { get; set; }
        public string TSegundoNombre { get; set; }
        public string TTelefono { get; set; }
        public string TTipoAfiliacion { get; set; }
        public UbicacionModel Ubicacion { get; set; }
        public MembershipModel EstadoAfiliacion { get; set; }
    }
}