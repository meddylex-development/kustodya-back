using System.Collections.Generic;

namespace Kustodya.ApplicationCore.DTOs
{
    public class DetallePerfilOutputModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EntidadId { get; set; }
        public int CreadoEl { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<MenuInputModel> MenusIds { get; set; }
    }
}