using System.Collections.Generic;

namespace Kustodya.ApplicationCore.DTOs
{
    public class PerfilConDetalleOutputModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CreadoEl { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<MenuOutputModel> Menus { get; set; }
    }
}