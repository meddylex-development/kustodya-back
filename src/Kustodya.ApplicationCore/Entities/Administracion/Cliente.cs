using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class Cliente
    {
        public int Id { get; set; }
        public TipoIdentificacion TipoId { get; set; }
        public string NumeroId { get; set; }
        public int EntidadId { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string RazonSocial { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string CorreoPrincipal { get; set; }
        public int? DigitoVerificacion { get; set; }
        public Regimen Regimen { get; set; }
        public Naturaleza Naturaleza { get; set; }
        public string NombreCompania { get; set; }
        public string CodigoExterno { get; set; }
        public string CodigoHabilitacion { get; set; }
        public int CodigoCIIU { get; set; }
        public Sociedad TipoSociedad { get; set; }
        public string Logo { get; set; }
        public bool Activo { get; set; }
        public Entidad Entidad { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public int UsuarioCreacion { get; set; }
        [Required]
        public DateTime FechaActualizacion { get; set; }
        [Required]
        public int UsuarioActualizacion { get; set; }
        public ICollection<ClienteDireccion> Direcciones { get; set; }
        public ICollection<ClienteTelefono> Telefonos { get; set; }
        public ICollection<ClienteCorreo> Correos { get; set; }
        public ICollection<ClienteRedSocial> RedesSociales { get; set; }
        public ICollection<UsuarioCliente> Usuarios { get; set; }
    }
}
