
using static Kustodya.ApplicationCore.Entities.MallaValidadora.Ips;

namespace Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada
{
    public class IpsInputModel
    {
        public Estados? Estado { get; set; }
        public string CodigoDaneMunicipio { get; set; }
    }
}