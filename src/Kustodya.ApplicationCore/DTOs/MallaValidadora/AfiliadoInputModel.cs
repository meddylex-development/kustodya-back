using System;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities.MallaValidadora;

namespace Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada
{
    public class AfiliadoInputModel
    {
        public DateTime? FechaNacimiento { get; set; }
        public Afiliado.TiposAfiliacion TipoAfiliacion { get; set; }

        public Sexos Sexo { get; set; }
        public string IpsNit { get; set; }
        public string? CodigoDaneMunicipio { get; set; }
        public bool? Activo { get; set; }
    }
}
