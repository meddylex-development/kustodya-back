using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class Entidad
    {
        public int Id { get; set; }
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
        public string SegundoApellido { get; set; }
        [Required]
        public string CorreoPrincipal { get; set; }
        public int? DigitoVerificacion { get; set; }
        public string Sucursal { get; set; }
        [Required]
        public Regimen Regimen { get; set; }
        [Required]
        public Naturaleza Naturaleza { get; set; }
        [Required]
        public int DiasContrasena { get; set; }
        public string NombreCompania { get; set; }
        public string CodigoExterno { get; set; }
        public string CodigoHabilitacion { get; set; }
        public int? CodigoCIIU { get; set; }
        public Sociedad? TipoSociedad { get; set; }
        public string Logo { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public int UsuarioCreacion { get; set; }
        [Required]
        public DateTime FechaActualizacion { get; set; }
        [Required]
        public int UsuarioActualizacion { get; set; }
        public Guid ContabilidadPorDefectoId { get; set; }
        public int? GerentePorDefectoId { get; set; }
        public int? CoordinadorPorDefectoId { get; set; }
        public int? InterventorPorDefectoId { get; set; }
        public int? AprobadorPorDefectoId { get; set; }
        public Entidad? EntidadRelacion { get; set; }
        public string CargoCoordinador { get; private set; }
        public string CargoInterventor { get; private set; }
        public string CargoGerente { get; private set; }
        public string CargoAprobadorContabilidad_1 { get; private set; }
        public string CargoAprobadorContabilidad_2 { get; private set; }
        public string CargoAprobadorOperativo_1 { get; private set; }
        public string CargoAprobadorOperativo_2 { get; private set; }
        public string TarjetaProfessionalContador1 { get; set; }
        public string TarjetaProfessionalContador2 { get; set; }
        public ICollection<EntidadDireccion> Direcciones { get; set; }
        public ICollection<EntidadTelefono> Telefonos { get; set; }
        public ICollection<EntidadCorreo> Correos { get; set; }
        public ICollection<EntidadRedSocial> RedesSociales { get; set; }
        public ICollection<EntidadOtro> Otros { get; set; }
        public ICollection<UsuarioEntidad> Usuarios { get; set; }

        // internal void EstablecerClaseDocumentoPorDefecto(Guid claseDocumentoId)
        // {
        //     this.ClaseDocumentoPorDefectoId = claseDocumentoId;
        // }

        public ICollection<Cliente> Clientes { get; set; }
        public void EstablecerContabilidadPorDefecto(Guid contabilidadId)
        {
            this.ContabilidadPorDefectoId = contabilidadId;
        }
        public void EstablecerGerente(int? idUsuario, string cargo) {
            if (idUsuario == 0) {
                GerentePorDefectoId = null;
            }
            //Validar si el usuario pertenece a esta entidad
            if (idUsuario != null) { 
                if (!Usuarios.Select(u => u.UsuarioId).Contains((int)idUsuario))
                    throw new Exception("El usuario no pertenece a la entidad");
                GerentePorDefectoId = idUsuario;
                CargoGerente = cargo;
            }
            
        }
        public void EstablecerCoordinador(int? idUsuario, string cargo)
        {
            if (idUsuario == 0)
            {
                CoordinadorPorDefectoId = null;
            }
            //Validar si el usuario pertenece a esta entidad
            if (idUsuario != null)
            {
                if (!Usuarios.Select(u => u.UsuarioId).Contains((int)idUsuario))
                    throw new Exception("El usuario no pertenece a la entidad");
                CoordinadorPorDefectoId = idUsuario;
                CargoCoordinador = cargo;
            }
            
        }
        public void EstablecerInterventor(int? idUsuario, string cargo)
        {
            if (idUsuario == 0)
            {
                InterventorPorDefectoId = null;
            }

            //Validar si el usuario pertenece a esta entidad
            if (idUsuario != null)
            {
                if (!Usuarios.Select(u => u.UsuarioId).Contains((int)idUsuario))
                    throw new Exception("El usuario no pertenece a la entidad");
                InterventorPorDefectoId = idUsuario;
                CargoInterventor = cargo;
            }
        }
        public void EstablecerAprobador(int? idUsuario)
        {
            if (idUsuario == 0)
            {
                this.AprobadorPorDefectoId = null;
            }

            //Validar si el usuario pertenece a esta entidad
            if (idUsuario != null)
            {
                if (!Usuarios.Select(u => u.UsuarioId).Contains((int)idUsuario))
                    throw new Exception("El usuario no pertenece a la entidad");
                this.AprobadorPorDefectoId = idUsuario;
            }
        }

        public bool TieneAprobadoresPorDefecto() {
            return GerentePorDefectoId != null && CoordinadorPorDefectoId != null && InterventorPorDefectoId != null;
        }

        public int ValidarDigitoVerificacion()
        {
            int n;
            bool isNumeric = int.TryParse(NumeroId, out n);
            if (!isNumeric)
                return 0;
            string unNit = NumeroId;
            string miTemp;
            int miContador;
            int miResiduo;
            int miChequeo;
            int[] miArregloPA = new int[15];
            miArregloPA[0] = 3;
            miArregloPA[1] = 7;
            miArregloPA[2] = 13;
            miArregloPA[3] = 17;
            miArregloPA[4] = 19;
            miArregloPA[5] = 23;
            miArregloPA[6] = 29;
            miArregloPA[7] = 37;
            miArregloPA[8] = 41;
            miArregloPA[9] = 43;
            miArregloPA[10] = 47;
            miArregloPA[11] = 53;
            miArregloPA[12] = 59;
            miArregloPA[13] = 67;
            miArregloPA[14] = 71;
            miChequeo = 0;
            miResiduo = 0;
            for (miContador = 0; miContador < unNit.Length; miContador++)
            {
                miTemp = unNit[(unNit.Length - 1) - miContador].ToString();
                miChequeo = miChequeo + (Convert.ToInt32(miTemp) * miArregloPA[miContador]);
            }
            miResiduo = miChequeo % 11;
            if (miResiduo > 1)
                return 11 - miResiduo;
            return miResiduo;
        }
    }
}
