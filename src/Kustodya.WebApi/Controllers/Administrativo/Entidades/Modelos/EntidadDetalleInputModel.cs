using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class EntidadDetalleInputModel
    {
        [Required]
        public TipoIdentificacion TipoId { get; set; }
        [Required]
        public string NumeroId { get; set; }
        public TipoEntidad? TipoEntidad { get; set; }
        public TipoRelacion? TipoRelacion { get; set; }
        public int? EntidadRelacionId { get; set; }
        public string RazonSocial { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string Sucursal { get; set; }
        public string SegundoApellido { get; set; }
        public string CorreoPrincipal { get; set; }
        public int? DigitoVerificacion { get; set; }
        public Regimen Regimen { get; set; }
        public Naturaleza Naturaleza { get; set; }
        public int DiasContrasena { get; set; }
        // [Required]
        public string NombreCompania { get; set; }
        public string CodigoExterno { get; set; }
        public string CodigoHabilitacion { get; set; }
        public int? CodigoCIIU { get; set; }
        public Sociedad? TipoSociedad { get; set; }
        public ICollection<TelefonoInputModel> Telefonos{ get; set; }
        public ICollection<CorreoInputModel> Correos { get; set; }
        public ICollection<DireccionInputModel> Direcciones { get; set; }
        public ICollection<RedSocialInputModel> RedesSociales { get; set; }
        public ICollection<OtroInputModel> Otros { get; set; }
    }
}
