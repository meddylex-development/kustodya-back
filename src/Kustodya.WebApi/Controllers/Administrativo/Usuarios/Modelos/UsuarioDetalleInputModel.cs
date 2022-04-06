using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class UsuarioDetalleInputModel
    {
        /// <summary>
        /// En la creación va en 0, en la edición va el id del usuario
        /// </summary>
        /// <example>0</example>
        public int Id { get; set; }
        /// <summary>
        /// El id del tipo de identificación según el servicio de Tipos de identificación
        /// </summary>
        /// <example>9</example>
        [Required]
        public int TipoIdentificacion { get; set; }
        /// <example>1234567890</example>
        [Required]
        [MaxLength(15)]
        public string NumeroIdentificacion { get; set; }
        /// <example>Pedro</example>
        [Required]
        [MaxLength(50)]
        public string PrimerNombre { get; set; }
        [MaxLength(50)]
        public string SegundoNombre { get; set; }
        /// <example>Perez</example>
        [Required]
        [MaxLength(50)]
        public string PrimerApellido { get; set; }
        [MaxLength(50)]
        public string SegundoApellido { get; set; }
        public int Sexo { get; set; }
        [Required]
        public string Correo { get; set; }
        public long FechaNacimiento { get; set; }
        /// <summary>
        /// El id del Perfil según el servicio de Perfiles
        /// </summary>
        /// /// <example>1</example>
        public int PerfilId { get; set; }
        /// <summary>
        /// true -> es medico, false -> no es medico
        /// </summary>
        /// /// <example>true</example>
        public bool? EsMedico { get; set; }
        public string RegistroMedico { get; set; }
        /// <summary>
        /// true -> El usuario requiere de otros tratamientos
        /// </summary>
        /// /// <example>true</example>
        public bool OtrosTratamientos { get; set; }
        public bool Activo { get; set; }
        public List<TelefonoInputModel> Telefonos { get; set; }
        public List<DireccionInputModel> Direcciones { get; set; }
        public List<CorreoInputModel> Correos { get; set; }
        public List<RedSocialInputModel> RedesSociales { get; set; }
        [Required]
        public List<EntidadInputModel> Entidades { get; set; }
    }
}
