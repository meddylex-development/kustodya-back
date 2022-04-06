using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class UsuarioInputModel
    {
        /// <summary>
        /// El id del tipo de identificación según el servicio de Tipos de identificación
        /// </summary>
        /// <example>9</example>
        [Required]
        public int TipoIdentificacion { get; set; }
        /// <example>1234567890</example>
        [Required]
        public string NumeroIdentificacion { get; set; }
        /// <example>Pedro</example>
        [Required]
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        /// <example>Perez</example>
        [Required]
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Sexo { get; set; }
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
    }
}
