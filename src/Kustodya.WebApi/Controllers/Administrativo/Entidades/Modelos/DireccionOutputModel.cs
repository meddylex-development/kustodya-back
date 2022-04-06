using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class DireccionOutputModel
    {
        public int Id { get; set; }
        public Via TipoViaPrincipal { get; set; }
        public int NumeroViaPrincipal { get; set; }
        public string LetraViaPrincipal { get; set; }
        public int NumeroViaSecundaria { get; set; }
        public string LetraViaSecundaria { get; set; }
        public int DistanciaInterseccion { get; set; }
        public string Indicaciones { get; set; }
    }
}
