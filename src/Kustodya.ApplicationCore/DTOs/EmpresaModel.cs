using System.ComponentModel.DataAnnotations;

namespace Kustodya.ApplicationCore.Dtos
{
    public class EmpresaModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string tNombreComercial { get; set; }

        [Required]
        public string tRazonSocial { get; set; }
    }
}