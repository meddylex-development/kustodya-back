using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class EntidadDetalleOutputModel
    {
        public int Id { get; set; }
        [Required]
        public int TipoId { get; set; }
        [Required]
        public string NumeroId { get; set; }
        //public TipoEntidad TipoEntidad { get; set; }
        public TipoRelacion? TipoRelacion { get; set; }
        public int? EntidadRelacionId { get; set; }
        public string RazonSocial { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string CorreoPrincipal { get; set; }
        public int? DigitoVerificacion { get; set; }
        public int Regimen { get; set; }
        public int Naturaleza { get; set; }
        public int DiasContrasena { get; set; }
        [Required]
        public string NombreCompania { get; set; }
        public string CodigoExterno { get; set; }
        public string CodigoHabilitacion { get; set; }
        public int CodigoCIIU { get; set; }
        public int TipoSociedad { get; set; }
        public int? GerentePorDefectoId { get; set; }
        public int? CoordinadorPorDefectoId { get; set; }
        public int? InterventorPorDefectoId { get; set; }
        public int? AprobadorPorDefectoId { get; set; }
        public string ContabilidadDefecto { get; set; }
        //public string Logo { get; set; }
        public List<TelefonoOutputModel> Telefonos{ get; set; }
        public List<DireccionOutputModel> Direcciones { get; set; }
        public List<CorreoOutputModel> Correos { get; set; }
        public List<RedSocialOutputModel> RedesSociales { get; set; }
        public List<ClienteOutputModel> Clientes { get; set; }
        public List<OtroOutputModel> Otros { get; set; }
    }
}
