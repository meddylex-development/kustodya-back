using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class UsuarioDetalleOutputModel
    {
        public int Id { get; set; }
        public int TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public long FechaNacimiento { get; set; }
        public int Perfil { get; set; }
        public bool EsMedico { get; set; }
        public string RegistroMedico { get; set; }
        //public string Entidad { get; set; }
        public bool OtrosTratamientos { get; set; }
        public bool Activo { get; set; }
        public string Correo { get; set; }
        public IReadOnlyList<TelefonoOutputModel> Telefonos { get; set; }
        public IReadOnlyList<DireccionOutputModel> Direcciones { get; set; }
        public IReadOnlyList<CorreoOutputModel> Correos { get; set; }
        public IReadOnlyList<RedSocialOutputModel> RedesSociales { get; set; }
        public IReadOnlyList<EPSOutputModel> EPSs { get; set; }
        public IReadOnlyList<EntidadOutputModel> Entidades { get; set; }
    }
}
