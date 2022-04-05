using Kustodya.ApplicationCore.Entities;
namespace Roojo.CalificacionOrigen
{
    public partial class Adjunto : BaseEntity
    {
        public int Id { get; set; }
        public int CorreoId { get; set; }
        public Correo Correo { get; set; }
        public string NombreArchivo { get; set; }
        public string Contenido { get; set; }
        public string TextoReconocido { get; set; }
    }
}