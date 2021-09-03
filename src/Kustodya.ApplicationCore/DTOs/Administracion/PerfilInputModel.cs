using System.Collections.Generic;

namespace Kustodya.ApplicationCore.DTOs
{
    public class PerfilInputModel
    {
        public int Id { get; set; }
        /// <example>Consultor</example>
        public string Nombre { get; set; }
        /// <example>1</example>
        public int EntidadId { get; set; }
        /// <example>true</example>
        public bool Activo { get; set; }
        public IEnumerable<MenuInputModel> Menus { get; set; }
    }
}