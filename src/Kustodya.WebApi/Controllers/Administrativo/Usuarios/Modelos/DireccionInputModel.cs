using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class DireccionInputModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TipoViaPrincipal { get; set; }
        public int NumeroViaPrincipal { get; set; }
        public string LetraViaPrincipal { get; set; }
        public int NumeroViaSecundaria { get; set; }
        public string LetraViaSecundaria { get; set; }
        public int DistanciaInterseccion { get; set; }
        public string Indicaciones { get; set; }
        public int DivipolaId { get; set; }
        /// <example>1</example>
    }
}
