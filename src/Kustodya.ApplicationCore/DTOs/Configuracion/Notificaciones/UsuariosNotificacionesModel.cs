namespace Kustodya.ApplicationCore.Dtos.Configuracion.Notificaciones
{
    public class UsuariosNotificacionesModel
    {
        public bool BActivo { get; set; }
        public int IId { get; set; }
        public int IIDIPS { get; set; }
        public string TCargo { get; set; }
        public string TEmail { get; set; }
        public string TNombreEmpresa { get; set; }
        public string TPrimerApellido { get; set; }
        public string TPrimerNombre { get; set; }
        public string TSegundoApellido { get; set; }
        public string TSegundoNombre { get; set; }
    }
}